using System.Threading;
using System.Threading.Tasks;
using Gore.Domain.Events.BloodType;
using MediatR;

namespace Gore.Domain.EventHandlers
{
    public class BloodTypeEventHandler : 
        INotificationHandler<BloodTypeRegisteredEvent>,
        INotificationHandler<BloodTypeUpdatedEvent>,
        INotificationHandler<BloodTypeRemovedEvent>
    {
        public Task Handle(BloodTypeRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(BloodTypeUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(BloodTypeRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
