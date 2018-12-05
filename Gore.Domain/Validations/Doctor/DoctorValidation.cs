using FluentValidation;
using Gore.Domain.Commands.Doctor;

namespace Gore.Domain.Validations.Doctor
{
    public abstract class DoctorValidation<T> : AbstractValidator<T> where T : DoctorCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.DoctorId)
                .NotEqual(int.MinValue);
        }

        protected void ValidateCrm()
        {
            RuleFor(c => c.CRM)
                .NotEmpty().WithMessage("Por favor, informe o seu CRM");
        }
    }
}
