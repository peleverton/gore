using Gore.Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace Gore.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(int aggregateId);
    }
}
