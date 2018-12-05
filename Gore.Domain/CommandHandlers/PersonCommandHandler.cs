using System.Threading;
using System.Threading.Tasks;
using Gore.Domain.Commands.Person;
using Gore.Domain.Core.Bus;
using Gore.Domain.Core.Notifications;
using Gore.Domain.Events.Person;
using Gore.Domain.Interfaces;
using Gore.Domain.Models;
using MediatR;

namespace Gore.Domain.CommandHandlers
{
    public class PersonCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewPersonCommand>,
        IRequestHandler<RemovePersonCommand>,
        IRequestHandler<UpdatePersonCommand>
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMediatorHandler Bus;
        public PersonCommandHandler(IPersonRepository personRepository,IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _personRepository = personRepository;
            Bus = bus;
        }

        public Task Handle(RegisterNewPersonCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }
                                    
            var person = new Person(message.FirstName, message.LastName, message.CPF, message.Email, message.DateOfBirth, message.Phone, message.Address, message.Gender, message.IsActive, new BloodType(message.BloodType,""));

            _personRepository.Add(person);

            if (Commit())
                Bus.RaiseEvent(new PersonRegisteredEvent(person.FirstName, person.LastName, person.CPF, person.Email, person.DateOfBirth, person.Phone, person.Address, person.Gender, person.IsActive, person.BloodType.BloodTypeId));

            return Task.CompletedTask;
        }

        public Task Handle(RemovePersonCommand message, CancellationToken cancellationToken)
        {

            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _personRepository.Remove(message.PersonId);

            if (Commit())
                Bus.RaiseEvent(new PersonRemovedEvent(message.PersonId));

            return Task.CompletedTask;
        }

        public Task Handle(UpdatePersonCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var person = new Person(message.PersonId, message.FirstName, message.LastName, message.CPF, message.Email, message.DateOfBirth, message.Phone, message.Address, message.Gender, message.IsActive, new BloodType(message.BloodType, ""));

            _personRepository.Update(person);

            if (Commit())
                Bus.RaiseEvent(new PersonUpdatedEvent(person.PersonId, person.FirstName, person.LastName, person.CPF, person.Email, person.DateOfBirth, person.Phone, person.Address, person.Gender, person.IsActive, person.BloodType.BloodTypeId));

            return Task.CompletedTask;
        }
    }
}
