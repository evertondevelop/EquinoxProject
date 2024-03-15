using Microsoft.Extensions.DependencyInjection;

namespace Equinox.UI.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Register your services here, using the extension methods provided by the Microsoft.Extensions.DependencyInjection namespace
            // For example:
            // services.AddTransient<IMyService, MyService>();

            return services;
        }
    }
}


services.AddTransient<IMyService, MyService>();
