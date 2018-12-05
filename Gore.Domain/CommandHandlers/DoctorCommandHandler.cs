using System.Threading;
using System.Threading.Tasks;
using Gore.Domain.Commands.Doctor;
using Gore.Domain.Core.Bus;
using Gore.Domain.Core.Notifications;
using Gore.Domain.Events.Doctor;
using Gore.Domain.Interfaces;
using Gore.Domain.Models;
using MediatR;

namespace Gore.Domain.CommandHandlers
{
    public class DoctorCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewDoctorCommand>,
        IRequestHandler<RemoveDoctorCommand>, 
        IRequestHandler<UpdateDoctorCommand>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMediatorHandler Bus;

        public DoctorCommandHandler(IDoctorRepository doctorRepository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _doctorRepository = doctorRepository;
            Bus = bus;
        }

        public Task Handle(RegisterNewDoctorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var doctor = new Doctor(message.DoctorId, message.CRM, message.Person);

            _doctorRepository.Add(doctor);

            if (Commit())
                Bus.RaiseEvent(new DoctorRegisteredEvent(message.DoctorId, message.CRM, message.Person));

            return Task.CompletedTask;
        }

        public Task Handle(RemoveDoctorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _doctorRepository.Remove(message.DoctorId);

            if (Commit())
                Bus.RaiseEvent(new DoctorRemovedEvent(message.DoctorId));

            return Task.CompletedTask;
        }

        public Task Handle(UpdateDoctorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var doctor = new Doctor(message.DoctorId, message.CRM, message.Person);

            _doctorRepository.Add(doctor);

            if (Commit())
                Bus.RaiseEvent(new DoctorUpdatedEvent(message.DoctorId, message.CRM));

            return Task.CompletedTask;
        }
    }
}
