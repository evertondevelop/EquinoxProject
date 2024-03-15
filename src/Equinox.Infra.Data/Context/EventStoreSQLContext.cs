using Equinox.Domain.Core.Events; // Needed for working with domain events
using Equinox.Infra.Data.Mappings;   // Needed for configuring database mappings
using Microsoft.EntityFrameworkCore; // Needed for using Entity Framework Core

namespace Equinox.Infra.Data.Context // Namespace for the database context
{
    public class EventStoreSqlContext : DbContext // Class for the database context
    {
        // Constructor for the database context that accepts options for configuration
        public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options) : base(options) { }

        // Database set for the StoredEvent entity
        public DbSet<StoredEvent> StoredEvent { get; set; }

        // Method called when the model is being created
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply the StoredEventMap configuration to the model builder
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            // Call the base implementation of OnModelCreating
            base.OnModelCreating(modelBuilder);
        }
    }
}
