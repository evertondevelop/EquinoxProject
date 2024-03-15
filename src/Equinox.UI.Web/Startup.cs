using Equinox.Infra.CrossCutting.Identity;
using Equinox.UI.Web.Configurations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetDevPack.Identity;
using NetDevPack.Identity.User;
using System;
using System.IO;

namespace Equinox.UI.Web
{
    public class Startup
    {
        private readonly IHostEnvironment _env;
        public IHostEnvironment Env => _env;
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            #region MVC Settings

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            services.AddRazorPages();

            #endregion

            #region Database Configuration

            services.AddDatabaseConfiguration(Configuration);

            #endregion

            #region ASP.NET Identity Settings

            services.AddWebAppIdentityConfiguration(Configuration);

            #endregion

            #region Authentication & Authorization

            services.AddSocialAuthenticationConfiguration(Configuration);

            #endregion

            #region NetDevPack.Identity dependency

            services.AddAspNetUserConfiguration();

            #endregion

            #region AutoMapper Settings

            services.AddAutoMapperConfiguration();

            #endregion

            #region MediatR Settings

            services.AddMediatR(typeof(Startup));

            #endregion

            #region .NET Native DI Abstraction

            services.AddDependencyInjectionConfiguration();

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/error/500");
                app.UseStatusCodePagesWithRedirects("/error/{0}");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            #region NetDevPack.Identity dependency

            app.UseAuthConfiguration();

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
