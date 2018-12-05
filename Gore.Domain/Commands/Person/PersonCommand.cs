using Gore.Domain.Core.Commands;
using Gore.Domain.Models;
using System;

namespace Gore.Domain.Commands.Person
{
    public abstract class PersonCommand : Command
    {
        public int PersonId { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public long CPF { get; protected set; }
        public string Email { get; protected set; }
        public DateTime DateOfBirth { get; protected set; }
        public int Phone { get; protected set; }
        public virtual Address Address { get; protected set; }
        public virtual Gender Gender { get; protected set; }
        public bool IsActive { get; protected set; }
        public int BloodType { get; protected set; }
    }
}
