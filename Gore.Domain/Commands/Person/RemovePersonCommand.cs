using Gore.Domain.Validations.Person;

namespace Gore.Domain.Commands.Person
{
    public class RemovePersonCommand : PersonCommand
    {
        public RemovePersonCommand(int id)
        {
            PersonId = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemovePersonCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
