using Gore.Domain.Core.Events;

namespace Gore.Domain.Events.BloodType
{
    public class BloodTypeRegisteredEvent : Event
    {
        public BloodTypeRegisteredEvent(string bloodTypeDescription)
        {
            //BloodTypeId = 1;
            BloodTypeDescription = bloodTypeDescription;
        }

        //public int BloodTypeId { get; set; }

        public string BloodTypeDescription { get; private set; }
    }
}
