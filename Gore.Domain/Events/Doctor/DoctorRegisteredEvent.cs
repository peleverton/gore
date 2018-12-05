using Gore.Domain.Core.Events;
using Gore.Domain.Models;
using System.Collections.Generic;

namespace Gore.Domain.Events.Doctor
{
    public class DoctorRegisteredEvent : Event
    {
        public DoctorRegisteredEvent(int? doctorId, string crm, Gore.Domain.Models.Person person)
        {
            DoctorId = doctorId;
            CRM = crm;
            Person = person;
        }

        public int? DoctorId { get; private set; }

        public string CRM { get; private set; }

        public Gore.Domain.Models.Person Person { get; set; }

        public ICollection<Patient> Patients { get; set; }
    }
}
