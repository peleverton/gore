using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gore.Domain.Models
{
    public class Address
    {
        public Address(string street, int number, string cep, string complement, string city, string state, string neighborhood)
        {
            Street = street;
            Number = number;
            Cep = cep;
            Complement = complement;
            City = city;
            State = state;
            Neighborhood = neighborhood;
        }

        public Address(int? addressId, string street, int number, string cep, string complement, string city, string state, string neighborhood)
        {
            AddressId = addressId;
            Street = street;
            Number = number;
            Cep = cep;
            Complement = complement;
            City = city;
            State = state;
            Neighborhood = neighborhood;
        }

        protected Address() { }

        [BindNever]
        public int? AddressId { get; private set; }

        public string Street { get; private set; }

        public int Number { get; private set; }

        public string Cep { get; private set; }

        public string Complement { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string Neighborhood { get; private set; }
    }
}
