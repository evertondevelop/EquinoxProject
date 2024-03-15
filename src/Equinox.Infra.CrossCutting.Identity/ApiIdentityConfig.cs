using Microsoft.EntityFrameworkCore; // Required for using Entity Framework Core
using Microsoft.Extensions.Configuration; // Required for using IConfiguration
using Microsoft.Extensions.DependencyInjection; // Required for using IServiceCollection
using NetDevPack.Identity; // Required for using NetDevPack.Identity
using NetDevPack.Identity.Jwt; // Required for using NetDevPack.Identity.Jwt

namespace Equinox.Infra.CrossCutting.Identity // The namespace for this file
{
    public static class ApiIdentityConfig // The name of the static class
    {
        public static void AddApiIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // Add Identity Entity Framework Context Configuration from NetDevPack.Identity
            // This method sets up the default EF context for Identity, using the connection string named "DefaultConnection"
            // and specifies the migrations assembly to be "Equinox.Infra.CrossCutting.Identity"
            services.AddIdentityEntityFrameworkContextConfiguration(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Equinox.Infra.CrossCutting.Identity")));

            // Add Identity configuration from NetDevPack.Identity
            // This method sets up the default Identity configuration
            services.AddIdentityConfiguration();

            // Add JWT configuration from NetDevPack.Identity
            // This method sets up the default JWT configuration using the provided configuration and section name
            services.AddJwtConfiguration(configuration, "AppSettings");
        }
    }
}
