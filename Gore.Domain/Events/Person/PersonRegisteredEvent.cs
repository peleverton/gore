using Gore.Domain.Core.Events;
using Gore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gore.Domain.Events.Person
{
    public class PersonRegisteredEvent : Event
    {
       
        public PersonRegisteredEvent(string firstName, string lastName, long cPF, string email, DateTime dateOfBirth, int phone, Address address, Gender gender, bool isActive, int bloodType)
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
