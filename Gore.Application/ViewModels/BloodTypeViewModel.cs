using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gore.Application.ViewModels
{
    public class BloodTypeViewModel
    {
        [Required(ErrorMessage = "The BloodTypeDescription is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("BloodTypeDescription")]
        public string BloodTypeDescription { get; set; }

        public int BloodTypeId { get; set; }
    }
}
