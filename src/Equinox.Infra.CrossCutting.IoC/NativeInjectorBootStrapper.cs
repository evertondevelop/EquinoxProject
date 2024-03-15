using Equinox.Application.Interfaces; // Equinox application interfaces namespace
using Equinox.Application.Services; // Equinox application services namespace
using Equinox.Domain.Commands; // Equinox domain commands namespace
using Equinox.Domain.Core.Events; // Equinox domain core events namespace
using Equinox.Domain.Events; // Equinox domain events namespace
using Equinox.Domain.Interfaces; // Equinox domain interfaces namespace
using Equinox.Infra.CrossCutting.Bus; // Equinox infrastructure cross-cutting bus namespace
using Equinox.Infra.Data.Context; // Equinox infrastructure data context namespace
using Equinox.Infra.Data.EventSourcing; // Equinox infrastructure data event sourcing namespace
using Equinox.Infra.Data.Repository; // Equinox infrastructure data repository namespace
using Equinox.Infra.Data.Repository.EventSourcing; // Equinox infrastructure data repository event sourcing namespace
using FluentValidation.Results; // FluentValidation results namespace
using MediatR; // MediatR namespace
using Microsoft.Extensions.DependencyInjection; // Microsoft.Extensions.DependencyInjection namespace
using NetDevPack.Mediator; // NetDevPack Mediator namespace

namespace Equinox.Infra.CrossCutting.IoC // Equinox infrastructure cross-cutting IoC namespace
{
    public static class NativeInjectorBootStrapper // NativeInjectorBootStrapper class
    {
        public static void RegisterServices(IServiceCollection services) // RegisterServices method
        {
            // Registering Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>(); // Registering InMemoryBus as a scoped service for IMediatorHandler

            // Registering Application services
            services.AddScoped<ICustomerAppService, CustomerAppService>(); // Registering CustomerAppService as a scoped service for ICustomerAppService

            // Registering Domain - Events
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>(); // Registering CustomerEventHandler as a scoped service for INotificationHandler<CustomerRegisteredEvent>
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>(); // Registering CustomerEventHandler as a scoped service for INotificationHandler<CustomerUpdatedEvent>
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>(); // Registering CustomerEventHandler as a scoped service for INotificationHandler<CustomerRemovedEvent>

            // Registering Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, ValidationResult>, CustomerCommandHandler>(); // Registering CustomerCommandHandler as a scoped service for IRequestHandler<RegisterNewCustomerCommand, ValidationResult>
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, ValidationResult>, CustomerCommandHandler>(); // Registering CustomerCommandHandler as a scoped service for IRequestHandler<UpdateCustomerCommand, ValidationResult>
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, ValidationResult>, CustomerCommandHandler>(); // Registering CustomerCommandHandler as a scoped service for IRequestHandler<RemoveCustomerCommand, ValidationResult>

            // Registering Infra - Data repositories
            services.AddScoped<ICustomerRepository, CustomerRepository>(); // Registering CustomerRepository as a scoped service for I
