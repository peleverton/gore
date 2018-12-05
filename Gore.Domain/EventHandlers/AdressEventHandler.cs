using System.Threading;
using System.Threading.Tasks;
using Gore.Domain.Events.Adress;
using MediatR;

namespace Gore.Domain.EventHandlers
{
    public class AdressEventHandler :
        INotificationHandler<AdressRegisteredEvent>,
        INotificationHandler<AdressUpdatedEvent>,
        INotificationHandler<AdressRemovedEvent>
    {
        public Task Handle(AdressRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(AdressUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(AdressRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
