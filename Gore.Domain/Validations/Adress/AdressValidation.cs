using Gore.Domain.Commands.Adress;
using FluentValidation;

namespace Gore.Domain.Validations.Adress
{
    public abstract class AdressValidation<T> : AbstractValidator<T> where T : AdressCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.AddressId)
                .NotEqual(int.MinValue);
        }

        protected void ValidateCep()
        {
            RuleFor(c => c.Cep)
                .NotEmpty().WithMessage("informe o seu cep");
        }
    }
}
