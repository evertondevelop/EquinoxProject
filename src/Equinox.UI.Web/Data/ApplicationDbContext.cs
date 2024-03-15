// Add using directives for required namespaces
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Equinox.UI.Web.Models; // Include the ApplicationUser model definition

// Define the custom ApplicationDbContext class that inherits from IdentityDbContext<ApplicationUser>
namespace Equinox.UI.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Constructor: Inject DbContextOptions<ApplicationDbContext> via dependency injection
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Override the OnModelCreating method to configure the model
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure the ApplicationUser entity
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
            });
        }
    }
}
