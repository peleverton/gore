using Gore.Domain.Commands.Person;

namespace Gore.Domain.Validations.Person
{
    public class RegisterNewPersonCommandValidation : PersonValidation<RegisterNewPersonCommand>
    {
        public RegisterNewPersonCommandValidation()
        {
            ValidateCpf();
        }
    }
}
