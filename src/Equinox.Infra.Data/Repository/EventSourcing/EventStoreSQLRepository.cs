using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Equinox.Domain.Core.Events; // Namespace for event-related classes
using Equinox.Infra.Data.Context; // Namespace for the context class
using Microsoft.EntityFrameworkCore; // Namespace for EF Core

namespace Equinox.Infra.Data.Repository.EventSourcing
{
    // This class implements the IEventStoreRepository interface and is responsible for handling event store operations
    public class EventStoreSqlRepository : IEventStoreRepository
    {
        // The constructor takes an instance of EventStoreSqlContext, which is used for database operations
        public EventStoreSqlRepository(EventStoreSqlContext context)
        {
            _context = context; // Assign the context to a private field
        }

        // The private field _context holds the instance of EventStoreSqlContext
        private readonly EventStoreSqlContext _context;

        // This method retrieves all stored events for a given aggregate ID asynchronously
        public async Task<IList<StoredEvent>> All(Guid aggregateId)
        {
            // Use LINQ to query the StoredEvent table for all events with the given aggregate ID
            // The results are returned as a list of StoredEvent objects asynchronously
            return await (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToListAsync();
        }

        // This method stores a given StoredEvent object in the database
        public void Store(StoredEvent theEvent)
        {
            // Add the StoredEvent object to the StoredEvent table in the database
            _context.StoredEvent.Add(theEvent);

            // Save the changes to the database
            _context.SaveChanges();
        }

        // This method disposes of the EventStoreSqlContext instance
        public void Dispose()
        {
            _context.Dispose(); // Call the Dispose method of the EventStoreSqlContext instance
        }
    }
}
