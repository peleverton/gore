using Gore.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gore.Application.ViewModels
{
    public class DoctorViewModel
    {
        #region Doutor

        public int DoctorId { get; set; } 

        [Required(ErrorMessage = "The CRM é Required")]
        [MaxLength(100)]
        [DisplayName("CRM")]

        public string CRM { get; set; } 

        #endregion

        public DoctorViewModel()
        {

        }

        #region Person
        public virtual Person Person { get; set; }
        public virtual PersonViewModel personViewModel { get; set; }
        #endregion
        
        #region Deletar
        ////public int PersonId { get; set; }

        //[Required(ErrorMessage = "The FirstName é Required")]
        //[MaxLength(100)]
        //[DisplayName("FirstName")]
        //public string FirstName { get; set; }

        //[Required(ErrorMessage = "The LastName is Required")]
        //[MaxLength(100)]
        //[DisplayName("LastName")]
        //public string LastName { get; set; }

        //[Required(ErrorMessage = "The CPF is Required")]
        //[DisplayName("CPF")]
        //public long CPF { get; set; }

        //[Required(ErrorMessage = "Informe o seu email")]
        ////[RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        ////[MinLength(2)]
        ////[MaxLength(100)]
        //[DisplayName("Email")]
        //public string Email { get; set; }

        //[Required(ErrorMessage = "The DateOfBirth is Required")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        //public DateTime DateOfBirth { get; set; }

        //[Required(ErrorMessage = "The Phone is Required")]
        //public int Phone { get; set; }

        //public bool IsActive { get; set; }
        //#endregion

        //#region Address
        //public virtual Address address { get; set; }
        //public int? AddressId { get; set; }

        //[Required(ErrorMessage = "The Street é Required")]
        //[MaxLength(100)]
        //[DisplayName("Street")]
        //public string Street { get; set; }

        //public int Number { get; set; }

        //[Required(ErrorMessage = "The Cep é Required")]
        //[DisplayName("Cep")]
        //public int Cep { get; set; }

        //public string Complement { get; set; }

        //[Required(ErrorMessage = "The City é Required")]
        //[MaxLength(100)]
        //[DisplayName("City")]
        //public string City { get; set; }

        //[Required(ErrorMessage = "The State é Required")]
        //[MaxLength(80)]
        //[DisplayName("State")]
        //public string State { get; set; }

        #endregion

        #region BloodType
        public virtual IEnumerable<BloodTypeViewModel> BloodTypes { get; set; }
        //public virtual BloodType _BloodType { get; set; }
        #endregion
        
    }
}
