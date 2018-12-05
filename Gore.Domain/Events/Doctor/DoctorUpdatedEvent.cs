using Gore.Domain.Core.Events;

namespace Gore.Domain.Events.Doctor
{
    public class DoctorUpdatedEvent : Event
    {
        public DoctorUpdatedEvent(int doctorId, string crm)
        {
            DoctorId = doctorId;
            CRM = crm;
        }

        public int DoctorId { get; private set; }

        public string CRM { get; private set; }
                
    }
}
