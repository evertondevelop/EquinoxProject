using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging; // Required for using the ConsoleLoggerOptions class

#if (CSHARP_VERSION >= 9)
using global::System; // Required for top-level statements in C# 9.0 or later
#endif

namespace Equinox.Services.Api
{
    [Description("The main class for the Equinox API services.")]
    [Version("1.0.0")]
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(loggingBuilder =>
                {
#if (CSHARP_VERSION >= 9)
                    loggingBuilder.ClearProviders(); // Clear all existing logging providers
#else
                    loggingBuilder.AddConsole(); // Add the console logging provider
#endif
                    loggingBuilder.SetMinimumLevel(LogLevel.Debug); // Set the minimum log level to Debug
                });
    }
}
