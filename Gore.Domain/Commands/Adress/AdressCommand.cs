using Gore.Domain.Core.Commands;

namespace Gore.Domain.Commands.Adress
{
    public abstract class AdressCommand : Command
    {
        public int AddressId { get; protected set; }

        public string Street { get; protected set; }

        public int Number { get; protected set; }

        public string Cep { get; protected set; }

        public string Complement { get; protected set; }

        public string City { get; protected set; }

        public string State { get; protected set; }
    }
}
