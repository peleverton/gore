using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gore.Domain.Models
{
    public class Doctor 
    {
        public Doctor(int doctorId, string crm, Person person)
        {
            DoctorId = doctorId;
            CRM = crm;
            Person = person;
        }

        public Doctor() { }

        [BindNever]
        public int DoctorId { get; private set; }

        public string CRM { get; private set; }

        public virtual Person Person { get; private set; }
                
        //public ICollection<Patient> Patients { get; set; }

    }
}