using Gore.Domain.Core.Events;

namespace Gore.Domain.Events.Doctor
{
    public class DoctorRemovedEvent : Event
    {
        public DoctorRemovedEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public int Id { get; set; }
    }
}
