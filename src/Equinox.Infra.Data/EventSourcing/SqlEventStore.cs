using Equinox.Domain.Core.Events;
using Equinox.Infra.Data.Repository.EventSourcing;
using NetDevPack.Identity.User;
using NetDevPack.Messaging;
using Newtonsoft.Json;
using System;

namespace Equinox.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IAspNetUser _user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository, IAspNetUser user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            try
            {
                var serializedData = JsonConvert.SerializeObject(theEvent);

                var storedEvent = new StoredEvent(
                    theEvent,
                    serializedData,
                    _user.Name ?? _user.GetUserEmail(),
                    "Equinox.Domain.Core.Events");

                _eventStoreRepository.Store(storedEvent);
            }
            catch (Exception ex)
            {
                // Log the exception here
                Console.WriteLine($"Error while serializing event: {ex.Message}");
            }
        }
    }
}
