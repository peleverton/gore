using Gore.Domain.Commands.Adress;

namespace Gore.Domain.Validations.Adress
{
    public class RegisterNewAdressCommandValidation : AdressValidation<RegisterNewAdressCommand>
    {
        public RegisterNewAdressCommandValidation()
        {
            ValidateCep();
        }
    }
}
