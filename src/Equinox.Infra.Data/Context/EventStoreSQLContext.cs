using Equinox.Domain.Core.Events;
using Equinox.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Equinox.Infra.Data.Context
{
    public class EventStoreSqlContext : DbContext
    {
        public EventStoreSqlContext(DbContextOptions<EventStoreSqlContext> options) : base(options)
        {
        }

        public DbSet<StoredEvent> StoredEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            // Add any necessary configuration options here, such as connection strings
            optionsBuilder.UseSqlServer("your-connection-string-here");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
