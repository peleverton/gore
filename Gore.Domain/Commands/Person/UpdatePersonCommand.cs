using Gore.Domain.Models;
using Gore.Domain.Validations.Person;
using System;

namespace Gore.Domain.Commands.Person
{
    public class UpdatePersonCommand : PersonCommand
    {
        public UpdatePersonCommand(int personId, string firstName, string lastName, long cPF, string email, DateTime dateOfBirth, int phone, Address address, Gender gender, bool isActive, int bloodType)
        {
            PersonId = personId;
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
            ValidationResult = new UpdatePersonCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
