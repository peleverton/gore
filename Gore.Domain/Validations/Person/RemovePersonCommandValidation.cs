using Gore.Domain.Commands.Person;

namespace Gore.Domain.Validations.Person
{
    public class RemovePersonCommandValidation : PersonValidation<PersonCommand>
    {
        public RemovePersonCommandValidation()
        {
            ValidateId();
        }
    }
}
