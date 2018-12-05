using FluentValidation;
using Gore.Domain.Commands.Person;

namespace Gore.Domain.Validations.Person
{
    public abstract class PersonValidation<T> : AbstractValidator<T> where T : PersonCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.PersonId)
                .NotEqual(int.MinValue);
        }

        protected void ValidateCpf()
        {
            RuleFor(c => c.CPF)
          .NotEmpty().WithMessage("Por favor, informe o seu Cpf");
        }
    }
}
