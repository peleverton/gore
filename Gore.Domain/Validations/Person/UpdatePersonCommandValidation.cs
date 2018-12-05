using Gore.Domain.Commands.Person;

namespace Gore.Domain.Validations.Person
{
    public class UpdatePersonCommandValidation : PersonValidation<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidation()
        {
            ValidateId();
            ValidateCpf();
        }
    }
}
