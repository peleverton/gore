using Gore.Domain.Validations.BloodType;

namespace Gore.Domain.Commands.BloodType
{
    public class RemoveNewBloodTypeCommand : BloodTypeCommand
    {
        public RemoveNewBloodTypeCommand(int id)
        {
            BloodTypeId = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveBloodTypeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
