using Gore.Domain.Core.Events;
using Gore.Domain.Models;
using System;

namespace Gore.Domain.Events.Person
{
    public class PersonUpdatedEvent : Event
    {
        public PersonUpdatedEvent(int personId, string firstName, string lastName, long cPF, string email, DateTime dateOfBirth, int phone, Address address, Gender gender, bool isActive, int bloodType)
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

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long CPF { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Phone { get; set; }
        public virtual Address Address { get; set; }
        public virtual Gender Gender { get; set; }
        public bool IsActive { get; set; }
        public int BloodType { get; set; }
    }
}
