using Gore.Domain.Commands.Adress;

namespace Gore.Domain.Validations.Adress
{
    public class UpdateAdressCommandValidation : AdressValidation<UpdateAdressCommand>
    {
        public UpdateAdressCommandValidation()
        {
            ValidateId();
            ValidateCep();
        }
    }
}
