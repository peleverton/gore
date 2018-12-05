using System;
using System.Threading;
using System.Threading.Tasks;
using Gore.Domain.Commands.BloodType;
using Gore.Domain.Core.Bus;
using Gore.Domain.Core.Notifications;
using Gore.Domain.Events.BloodType;
using Gore.Domain.Interfaces;
using Gore.Domain.Models;
using MediatR;

namespace Gore.Domain.CommandHandlers
{
    public class BloodTypeCommandHandler : CommandHandler, 
        IRequestHandler<RegisterNewBloodTypeCommand>,
        IRequestHandler<RemoveNewBloodTypeCommand>,
        IRequestHandler<UpdateBloodTypeCommand>
    {
        private readonly IBloodTypeRepository _bloodRepository;
        private readonly IMediatorHandler Bus;

        public BloodTypeCommandHandler(IBloodTypeRepository bloodRepository, IUnitOfWork uow, 
            IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _bloodRepository = bloodRepository;
            Bus = bus;
        }

        public Task Handle(RegisterNewBloodTypeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var bloodType = new BloodType(message.BloodTypeDescription);

            _bloodRepository.Add(bloodType);

            if(Commit())
            {
                Bus.RaiseEvent(new BloodTypeRegisteredEvent(bloodType.BloodTypeDescription));
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoveNewBloodTypeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.CompletedTask;
            }

            _bloodRepository.Remove(request.BloodTypeId);

            if (Commit())
            {
                Bus.RaiseEvent(new BloodTypeRemovedEvent(request.BloodTypeId));
            }

            return Task.CompletedTask;
        }

        public Task Handle(UpdateBloodTypeCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.CompletedTask;
            }

            var bloodtype = new BloodType(request.BloodTypeDescription);

            _bloodRepository.Update(bloodtype);

            if (Commit())
            {
                Bus.RaiseEvent(new BloodTypeUpdatedEvent (1,bloodtype.BloodTypeDescription));
            }

            return Task.CompletedTask;
        }
    }
}
