using FluentValidation;
using Gore.Domain.Commands.BloodType;

namespace Gore.Domain.Validations.BloodType
{
    public abstract class BloodTypeValidation<T> : AbstractValidator<T> where T : BloodTypeCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.BloodTypeId)
                .NotEqual(int.MinValue);
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.BloodTypeDescription)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }
    }
}
