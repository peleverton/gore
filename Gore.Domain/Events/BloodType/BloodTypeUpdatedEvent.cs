using Gore.Domain.Core.Events;

namespace Gore.Domain.Events.BloodType
{
    public class BloodTypeUpdatedEvent : Event
    {
        public BloodTypeUpdatedEvent(int id, string bloodTypeDescription)
        {
            Id = id;
            BloodTypeDescription = bloodTypeDescription;
        }

        public int Id { get; set; }

        public string BloodTypeDescription { get; private set; }
    }
}
