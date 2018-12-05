using System;
using System.ComponentModel.DataAnnotations;

namespace Gore.Domain.Models
{
    public class MedicalProcedure
    {
        protected MedicalProcedure() { }

        [Key]
        public int MedicalProcedureId { get; set; }

        public String MedicalProcedureDescription { get; set; }

        public DateTimeOffset? DateOfProcedure { get; set; }

        public string Materials { get; set; }
        
        public virtual Patient Patient { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
