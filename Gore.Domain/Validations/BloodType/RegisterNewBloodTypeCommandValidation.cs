using Gore.Domain.Commands.BloodType;

namespace Gore.Domain.Validations.BloodType
{
    public class RegisterNewBloodTypeCommandValidation : BloodTypeValidation<RegisterNewBloodTypeCommand>
    {
        public RegisterNewBloodTypeCommandValidation()
        {
            ValidateDescription();
        }
    }
}
