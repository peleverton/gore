using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gore.Domain.Models
{
    public class Person
    {
        public Person(int personId, string firstName, string lastName, long cPF, string email, DateTime dateOfBirth, int phone, Address address, Gender gender, bool isActive, BloodType bloodType)
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

        public Person(string firstName, string lastName, long cPF, string email, DateTime dateOfBirth, int phone, Address address, Gender gender, bool isActive, BloodType bloodType)
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

        protected Person() { }

        [BindNever]
        public int PersonId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public long CPF { get; private set; }
        public string Email { get; private set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Data Nascimento")]
        public DateTime DateOfBirth { get; private set; }
        public int Phone { get; private set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }            
        public Gender Gender { get; private set; }
        public bool IsActive { get; private set; }
        public virtual BloodType BloodType { get; set; }
    }
}
