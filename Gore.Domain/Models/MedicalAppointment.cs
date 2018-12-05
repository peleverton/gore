using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gore.Domain.Models
{
    public class MedicalAppointment
    {
        protected MedicalAppointment() { }

        [Key]
        public int MedicalAppointmentId { get; set; }

        public DateTimeOffset? SchedulingDate { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
