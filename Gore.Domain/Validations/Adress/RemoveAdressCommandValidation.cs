using Gore.Domain.Commands.Adress;

namespace Gore.Domain.Validations.Adress
{
    public class RemoveAdressCommandValidation : AdressValidation<RemoveAdressCommand>
    {
        public RemoveAdressCommandValidation()
        {
            ValidateId();
        }
    }
}
