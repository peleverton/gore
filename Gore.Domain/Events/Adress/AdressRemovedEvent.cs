using Gore.Domain.Core.Events;

namespace Gore.Domain.Events.Adress
{
    public class AdressRemovedEvent : Event
    {
        public AdressRemovedEvent(int id)
        {
            Id = id;
            AggregateId = id;
        }

        public int Id { get; set; }
    }
}
