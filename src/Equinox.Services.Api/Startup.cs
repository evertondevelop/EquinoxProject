using Equinox.Infra.CrossCutting.Identity; // Equinox's custom identity library
using Equinox.Services.Api.Configurations; // Configuration-related classes for the Equinox.Services.Api project
using MediatR; // For handling domain events and notifications
using Microsoft.AspNetCore.Builder; // Provides methods to add middleware to the ASP.NET Core pipeline
using Microsoft.AspNetCore.Hosting; // Provides hosting functionality for ASP.NET Core
using Microsoft.Extensions.Configuration; // Handles configuration settings
using Microsoft.Extensions.DependencyInjection; // Provides dependency injection services
using Microsoft.Extensions.Hosting; // Provides hosting functionality for ASP.NET Core
using NetDevPack.Identity; // NetDevPack's identity library
using NetDevPack.Identity.User; // NetDevPack's user-related classes

namespace Equinox.Services.Api // The main namespace for the Equinox Services API
{
    public class Startup // The main startup class for the application
    {
        public Startup(IHostEnvironment env) // Injects the hosting environment
        {
            var builder = new ConfigurationBuilder() // Initializes a new configuration builder
                .SetBasePath(env.ContentRootPath) // Sets the base path for the configuration to the content root path of the application
                .AddJsonFile("appsettings.json", true, true) // Adds the appsettings.json file to the configuration
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true); // Adds the appsettings.{env.EnvironmentName}.json file to the configuration

            if (env.IsDevelopment()) // If the application is running in development mode
            {
                builder.AddUserSecrets<Startup>(); // Adds user secrets to the configuration
            }

            builder.AddEnvironmentVariables(); // Adds environment variables to the configuration
            Configuration = builder.Build(); // Builds the configuration
        }

        public IConfiguration Configuration { get; } // The main configuration object for the application

        public void ConfigureServices(IServiceCollection services) // Configures the dependency injection container
        {
            // WebAPI Config
            services.AddControllers(); // Adds support for controllers to the dependency injection container

            // Setting DBContexts
            services.AddDatabaseConfiguration(Configuration); // Adds the database configuration to the dependency injection container

            // ASP.NET Identity Settings & JWT
            services.AddApiIdentityConfiguration(Configuration); // Adds the ASP.NET Identity configuration to the dependency injection container

            // Interactive AspNetUser (logged in)
            // NetDevPack.Identity dependency
            services.AddAspNetUserConfiguration(); // Adds the AspNetUser configuration to the dependency injection container

            // AutoMapper Settings
            services.AddAutoMapperConfiguration(); // Adds the AutoMapper configuration to the dependency injection container

            // Swagger Config
            services.AddSwaggerConfiguration(); // Adds the Swagger configuration to the dependency injection container

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup)); // Adds MediatR to the dependency injection container

            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfiguration(); // Adds the .NET Native DI Abstraction configuration to the dependency injection container
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // Configures the middleware pipeline
        {
            if (env.IsDevelopment()) // If the application is running in development mode
            {
                app.UseDeveloperExceptionPage(); // Adds the developer exception page middleware to the pipeline
            }

            app.UseHttpsRedirection(); // Adds the HTTPS redirection middleware to the pipeline

            app.UseRouting(); // Adds the routing middleware to the pipeline

            app.UseCors(c => // Adds the CORS middleware to the pipeline
            {
                c.AllowAnyHeader(); // Allows any header
                c.AllowAnyMethod(); // Allows any method
                c.AllowAnyOrigin(); // Allows any origin
            });

            // NetDevPack.Identity dependency
            app.UseAuthConfiguration(); // Adds the authentication middleware to the pipeline

            app.UseEndpoints(endpoints => // Adds the endpoint routing middleware to the pipeline
            {
              
