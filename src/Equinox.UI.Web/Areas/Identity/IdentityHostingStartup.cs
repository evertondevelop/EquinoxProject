using Microsoft.AspNetCore.Hosting;  // Using the Microsoft.AspNetCore.Hosting namespace

[assembly: HostingStartup(typeof(Equinox.UI.Web.Areas.Identity.IdentityHostingStartup))]
// The HostingStartup attribute identifies this class as the startup class for the Identity area of the Equinox.UI.Web application

namespace Equinox.UI.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup  // Implementing the IHostingStartup interface
    {
        public void Configure(IWebHostBuilder builder)  // Configuring the web host builder
        {
            builder.ConfigureServices((context, services) =>  // Configuring the services for the web host builder
            {
                // Add any necessary services for the Identity area here
            });
        }
    }
}
