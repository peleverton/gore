using Gore.Domain.Validations.BloodType;

namespace Gore.Domain.Commands.BloodType
{
    public class UpdateBloodTypeCommand : BloodTypeCommand
    {
        public UpdateBloodTypeCommand(int bloodTypeId, string bloodTypeDescription)
        {
            BloodTypeId = bloodTypeId;            
            BloodTypeDescription = bloodTypeDescription;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateBloodTypeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
