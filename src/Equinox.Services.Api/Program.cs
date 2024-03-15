using Microsoft.AspNetCore.Hosting; // Required for using the IWebHost interface
using Microsoft.Extensions.Hosting; // Required for using the IHostBuilder interface

namespace Equinox.Services.Api // The namespace for the Equinox API services
{
    public class Program // The main class for the application
    {
        public static void Main(string[] args) // The entry point of the application
        {
            CreateHostBuilder(args).Build().Run(); // Create the host, build it, and start it
        }

        public static IHostBuilder CreateHostBuilder(string[] args) // Method to create the host builder
        {
            return Host.CreateDefaultBuilder(args) // Create a default host builder with common configurations
                .ConfigureWebHostDefaults(webBuilder => // Configure the web host builder
                {
                    webBuilder.UseStartup<Startup>(); // Use the Startup class for configuring the web host
                });
        }
    }
}
