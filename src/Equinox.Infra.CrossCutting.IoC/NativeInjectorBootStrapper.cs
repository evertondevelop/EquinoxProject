using Equinox.Application.Interfaces;
using Equinox.Application.Services;
using Equinox.Domain.Commands;
using Equinox.Domain.Core.Events;
using Equinox.Domain.Events;
using Equinox.Domain.Interfaces;
using Equinox.Infra.Data.Context;
using Equinox.Infra.Data.EventSourcing;
using Equinox.Infra.Data.Repository;
using Equinox.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace Equinox.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Registering Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Registering Application services
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Registering Domain - Events
            services.RegisterMediatRHandlers(typeof(CustomerRegisteredEvent).Assembly);
            services.RegisterMediatRHandlers(typeof(CustomerUpdatedEvent).Assembly);
            services.RegisterMediatRHandlers(typeof(CustomerRemovedEvent).Assembly);

            // Registering Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, ValidationResult>, CustomerCommandHandler>();

            // Registering Infra - Data repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}


using System.Linq;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

public static class MediatRServiceCollectionExtensions
{
    public static void RegisterMediatRHandlers(this IServiceCollection services, params System.Reflection.Assembly[] assemblies)
    {
        services.AddMediatR(assemblies.SelectMany(a => a.GetTypes()).ToArray());
    }
}
