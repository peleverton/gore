using Gore.Domain.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gore.Application.ViewModels
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }

        [Required(ErrorMessage = "The FirstName é Required")]
        [MaxLength(100)]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The LasttName is Required")]
        [MaxLength(100)]
        [DisplayName("LastName")]
        public string LastName { get; set; }

        public long CPF { get; set; }

        [Required(ErrorMessage = "The E-mail is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Email")]
        public string Email { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data Nascimento")]
        public DateTime DateOfBirth { get; set; }

        public int Phone { get; set; }
        public virtual Address Address { get; set; }
        public virtual AddressViewModel AddressView { get; set; }
        //public virtual AddressViewModel AddressView { get; set; }
        public virtual Gender Gender { get; set; }
        public bool IsActive { get; set; }
        public virtual BloodType BloodType { get; set; }
        public int BloodTypeView { get; set; }

        public PersonViewModel()
        {

        }
    }
}
