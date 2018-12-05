using Gore.Domain.Commands.BloodType;

namespace Gore.Domain.Validations.BloodType
{
    public class RemoveBloodTypeCommandValidation : BloodTypeValidation<BloodTypeCommand>
    {
        public RemoveBloodTypeCommandValidation()
        {
            ValidateId();
        }
    }
}
