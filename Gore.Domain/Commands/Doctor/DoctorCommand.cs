using Gore.Domain.Core.Commands;
using Gore.Domain.Models;
using System.Collections.Generic;

namespace Gore.Domain.Commands.Doctor
{
    public abstract class DoctorCommand : Command
    {
        public int DoctorId { get; protected set; }
        public string CRM { get; protected set; }
        public Gore.Domain.Models.Person Person { get; protected set; }
        public ICollection<Patient> Patients { get; protected set; }
    }
}
