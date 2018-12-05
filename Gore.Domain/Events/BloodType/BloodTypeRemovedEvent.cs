using Gore.Domain.Core.Events;

namespace Gore.Domain.Events.BloodType
{
    public class BloodTypeRemovedEvent : Event
    {
        public BloodTypeRemovedEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public int Id { get; set; }
    }
}
