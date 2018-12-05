using System.Threading;
using System.Threading.Tasks;
using Gore.Domain.Events.Doctor;
using MediatR;

namespace Gore.Domain.EventHandlers
{
    public class DoctorEventHandler :
        INotificationHandler<DoctorRegisteredEvent>,
        INotificationHandler<DoctorUpdatedEvent>,
        INotificationHandler<DoctorRemovedEvent>
    {
        public Task Handle(DoctorRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DoctorUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DoctorRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
