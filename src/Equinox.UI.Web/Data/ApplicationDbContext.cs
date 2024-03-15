using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Needed to inherit from IdentityDbContext
using Microsoft.EntityFrameworkCore;                    // Needed for database context

namespace Equinox.UI.Web.Data
{
    // ApplicationDbContext: Custom database context that inherits from IdentityDbContext
    // to include ASP.NET Core Identity functionality (e.g. user management).
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Constructor: Injects DbContextOptions<ApplicationDbContext> via dependency injection
        // to configure the database connection and other options.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
