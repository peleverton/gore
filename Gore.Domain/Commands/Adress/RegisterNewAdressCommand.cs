﻿using Gore.Domain.Validations.Adress;

namespace Gore.Domain.Commands.Adress
{
    public class RegisterNewAdressCommand : AdressCommand
    {
        public RegisterNewAdressCommand(string street, int number, string cep, string complement, string city, string state, string neighborhood)
        {
            //AddressId = addressId;
            Street = street;
            Number = number;
            Cep = cep;
            Complement = complement;
            City = city;
            State = state;
            Neighborhood = neighborhood;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewAdressCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
