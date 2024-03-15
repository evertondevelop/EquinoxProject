using Equinox.Infra.CrossCutting.Identity; // Equinox.Infra.CrossCutting.Identity namespace is used.
using Equinox.UI.Web.Configurations; // Equinox.UI.Web.Configurations namespace is used.
using MediatR; // MediatR namespace is used for Domain Events and Notifications.
using Microsoft.AspNetCore.Builder; // Microsoft.AspNetCore.Builder namespace is used.
using Microsoft.AspNetCore.Hosting; // Microsoft.AspNetCore.Hosting namespace is used.
using Microsoft.AspNetCore.Mvc; // Microsoft.AspNetCore.Mvc namespace is used.
using Microsoft.Extensions.Configuration; // Microsoft.Extensions.Configuration namespace is used.
using Microsoft.Extensions.DependencyInjection; // Microsoft.Extensions.DependencyInjection namespace is used.
using Microsoft.Extensions.Hosting; // Microsoft.Extensions.Hosting namespace is used.
using NetDevPack.Identity; // NetDevPack.Identity namespace is used for User management.
using NetDevPack.Identity.User; // NetDevPack.Identity.User namespace is used for User management.

namespace Equinox.UI.Web // Equinox.UI.Web namespace is used.
{
    public class Startup // Startup class is used to configure services and pipeline.
    {
        public Startup(IHostEnvironment env) // IHostEnvironment is injected through constructor.
        {
            var builder = new ConfigurationBuilder() // ConfigurationBuilder is used to build configuration.
                .SetBasePath(env.ContentRootPath) // Base path is set to ContentRootPath of IHostEnvironment.
                .AddJsonFile("appsettings.json", true, true) // appsettings.json is added to configuration.
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true); // Environment specific json is added to configuration.

            if (env.IsDevelopment()) // If environment is Development, UserSecrets are added to configuration.
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables(); // Environment variables are added to configuration.
            Configuration = builder.Build(); // Configuration is built.
        }

        public IConfiguration Configuration { get; } // IConfiguration is exposed as property.

        public void ConfigureServices(IServiceCollection services) // ConfigureServices method is used to configure services.
        {
            // MVC Settings
            services.AddControllersWithViews(options => // Controllers with views are added to services.
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()); // Antiforgery token validation is added.
            });
            services.AddRazorPages(); // Razor pages are added to services.

            // Setting DBContexts
            services.AddDatabaseConfiguration(Configuration); // Database configuration is added to services.

            // ASP.NET Identity Settings
            services.AddWebAppIdentityConfiguration(Configuration); // Web app identity configuration is added to services.

            // Authentication & Authorization
            services.AddSocialAuthenticationConfiguration(Configuration); // Social authentication configuration is added to services.

            // Interactive AspNetUser (logged in)
            // NetDevPack.Identity dependency
            services.AddAspNetUserConfiguration(); // AspNetUser configuration is added to services.

            // AutoMapper Settings
            services.AddAutoMapperConfiguration(); // AutoMapper configuration is added to services.

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup)); // MediatR is added to services with Startup type.

            // .NET Native DI Abstraction
            services.AddDependencyInjectionConfiguration(); // Dependency injection configuration is added to services.
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // Configure method is used to configure HTTP request pipeline.
        {
            if (env.IsDevelopment()) // If environment is Development, Development specific configurations are added.
            {
                app.UseDeveloperExceptionPage(); // Developer exception page is used.
                app.UseMigrationsEndPoint(); // Migrations endpoint is used.
            }
            else
            {
                app.UseExceptionHandler("/error/500"); // Exception handler is used for 500 errors.
                app.UseStatusCodePagesWithRedirects("/error/{0}"); // Status code pages with redirects are used.
                app.UseHsts(); // HTTP Strict Transport Security is used.
            }

            app.UseHttpsRedirection(); // HTTPS redirection is used.
            app.UseStaticFiles(); // Static files are used.

            app.UseRouting(); // Routing is used.

            // NetDevPack.Identity dependency
            app.UseAuthConfiguration(); // Auth configuration is used.

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute( // Controller route is mapped.
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages(); // Razor pages are mapped.
            });
        }
    }
}
