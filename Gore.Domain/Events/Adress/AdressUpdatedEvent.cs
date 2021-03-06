﻿using Gore.Domain.Core.Events;

namespace Gore.Domain.Events.Adress
{
    public class AdressUpdatedEvent : Event
    {
        public AdressUpdatedEvent(int addressId, string street, int number, string cep, string complement, string city, string state)
        {
            AddressId = addressId;
            Street = street;
            Number = number;
            Cep = cep;
            Complement = complement;
            City = city;
            State = state;
        }

        public int AddressId { get; private set; }

        public string Street { get; private set; }

        public int Number { get; private set; }

        public string Cep { get; private set; }

        public string Complement { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }
    }
}
