using Gore.Domain.Models;
using Gore.Domain.Validations.Person;
using System;

namespace Gore.Domain.Commands.Person
{
    public class RegisterNewPersonCommand : PersonCommand
    {
        public RegisterNewPersonCommand(string firstName, string lastName, long cPF, string email, DateTime dateOfBirth, int phone, Address address, Gender gender, bool isActive, int bloodType)
        {
            FirstName = firstName;
            LastName = lastName;
            CPF = cPF;
            Email = email;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Address = address;
            Gender = gender;
            IsActive = isActive;
            BloodType = bloodType;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewPersonCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
