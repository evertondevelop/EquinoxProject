using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Equinox.UI.Web.Configurations
{
    public static class IdentityConfig
    {
        /// <summary>
        /// Adds social authentication configuration to the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add the configuration to.</param>
        /// <param name="configuration">The IConfiguration to read configuration values from.</param>
        public static void AddSocialAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            services.AddAuthentication()
                // Add Facebook authentication
                .AddFacebook(o =>
                {
                    // Configure Facebook authentication with app ID and secret
                    o.AppId = configuration.GetValue<string>("Authentication:Facebook:AppId");
                    o.AppSecret = configuration.GetValue<string>("Authentication:Facebook:AppSecret");
                })
                // Add Google authentication
                .AddGoogle(googleOptions =>
                {
                    // Configure Google authentication with client ID and secret
                    googleOptions.ClientId = configuration.GetValue<string>("Authentication:Google:ClientId");
                    googleOptions.ClientSecret = configuration.GetValue<string>("Authentication:Google:ClientSecret");
                });
        }
    }
}
