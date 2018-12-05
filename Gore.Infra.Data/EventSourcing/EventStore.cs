using Gore.Domain.Core.Events;
using Gore.Infra.Data.Repository.EventSourcing;
using Newtonsoft.Json;

namespace Gore.Infra.Data.EventSourcing
{
    public class EventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public EventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "Pl10");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
