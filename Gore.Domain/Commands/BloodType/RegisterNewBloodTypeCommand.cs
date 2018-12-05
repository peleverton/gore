using Gore.Domain.Validations.BloodType;

namespace Gore.Domain.Commands.BloodType
{
    public class RegisterNewBloodTypeCommand : BloodTypeCommand
    {
        public RegisterNewBloodTypeCommand(string bloodTypeDescription)
        {
            BloodTypeDescription = bloodTypeDescription;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewBloodTypeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
