using System;
using Equinox.Infra.CrossCutting.IoC; // This using statement includes the NativeInjectorBootStrapper class, which is used to register services in the DI container.
using Microsoft.Extensions.DependencyInjection; // This using statement includes the IServiceCollection interface, which is used to configure services in the DI container.

namespace Equinox.Services.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        /// <summary>
        /// Adds the dependency injection configuration to the specified IServiceCollection. This includes registering services using the NativeInjectorBootStrapper class.
        /// </summary>
        /// <param name="services">The IServiceCollection to which the dependency injection configuration will be added.</param>
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services)); // Validates that the services parameter is not null.

            // Registers services using the NativeInjectorBootStrapper class.
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
