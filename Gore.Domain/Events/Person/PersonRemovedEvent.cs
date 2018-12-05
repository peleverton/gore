using Gore.Domain.Core.Events;

namespace Gore.Domain.Events.Person
{
    public class PersonRemovedEvent : Event
    {
        public PersonRemovedEvent(int personId)
        {
            PersonId = personId;
        }

        public int PersonId { get; set; }
    }
}
