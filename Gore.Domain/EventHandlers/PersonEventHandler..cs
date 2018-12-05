using System.Threading;
using System.Threading.Tasks;
using Gore.Domain.Events.Person;
using MediatR;

namespace Gore.Domain.EventHandlers
{
    public class PersonEventHandler :
        INotificationHandler<PersonRegisteredEvent>,
        INotificationHandler<PersonRemovedEvent>,
        INotificationHandler<PersonUpdatedEvent>
    {
        public Task Handle(PersonRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PersonRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PersonUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
