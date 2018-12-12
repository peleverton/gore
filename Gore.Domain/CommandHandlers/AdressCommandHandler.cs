using System.Threading;
using System.Threading.Tasks;
using Gore.Domain.Commands.Adress;
using Gore.Domain.Core.Bus;
using Gore.Domain.Core.Notifications;
using Gore.Domain.Events.Adress;
using Gore.Domain.Interfaces;
using Gore.Domain.Models;
using MediatR;

namespace Gore.Domain.CommandHandlers
{
    public class AdressCommandHandler : CommandHandler,
         IRequestHandler<RegisterNewAdressCommand>,
         IRequestHandler<RemoveAdressCommand>,
         IRequestHandler<UpdateAdressCommand>
    {

        private readonly IAdressRepository _adressRepository;
        private readonly IMediatorHandler Bus;

        public AdressCommandHandler(IAdressRepository adressRepository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _adressRepository = adressRepository;
            Bus = bus;
        }

        public Task Handle(RegisterNewAdressCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var adress = new Address(message.Street, message.Number, message.Cep, message.Complement, message.City, message.State, message.Neighborhood);

            _adressRepository.Add(adress);

            if (Commit())
                Bus.RaiseEvent(new AdressRegisteredEvent(message.AddressId, message.Street, message.Number, message.Cep, message.Complement, message.City, message.State, message.Neighborhood));

            return Task.CompletedTask;
        }

        public Task Handle(RemoveAdressCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _adressRepository.Remove(message.AddressId);

            if (Commit())
                Bus.RaiseEvent(new AdressRemovedEvent(message.AddressId));

            return Task.CompletedTask;
        }

        public Task Handle(UpdateAdressCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var adress = new Address(message.AddressId, message.Street, message.Number, message.Cep, message.Complement, message.City, message.State, message.Neighborhood);

            _adressRepository.Update(adress);

            if (Commit())
                Bus.RaiseEvent(new AdressUpdatedEvent(message.AddressId, adress.Street, adress.Number, adress.Cep, adress.Complement, adress.City, adress.State));

            return Task.CompletedTask;
        }
    }
}
