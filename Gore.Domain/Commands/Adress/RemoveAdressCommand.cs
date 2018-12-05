using Gore.Domain.Validations.Adress;

namespace Gore.Domain.Commands.Adress
{
    public class RemoveAdressCommand : AdressCommand
    {
        public RemoveAdressCommand(int id)
        {
            AddressId = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveAdressCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
