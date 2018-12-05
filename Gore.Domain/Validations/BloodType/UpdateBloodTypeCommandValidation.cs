using Gore.Domain.Commands.BloodType;

namespace Gore.Domain.Validations.BloodType
{
    public class UpdateBloodTypeCommandValidation : BloodTypeValidation<UpdateBloodTypeCommand>
    {
        public UpdateBloodTypeCommandValidation()
        {
            ValidateId();
            ValidateDescription();
        }
    }
}
