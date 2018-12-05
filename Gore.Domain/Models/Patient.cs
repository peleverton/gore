using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gore.Domain.Models
{
    public class Patient 
    {
        protected Patient() { }

        [Key]
        public int PatientId { get; set; }
                
        public double Weight { get; set; }

        public double Height { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string Picture { get; set; }

        public bool Active { get; set; }

        public virtual Person Person { get; set; }

        [NotMapped]
        public ICollection<Doctor> Doctors { get; set; }
               
        public DateTimeOffset? CreatedAt { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

    }
}
