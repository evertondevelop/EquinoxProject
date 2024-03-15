using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Equinox.Application.EventSourcedNormalizers;
using Equinox.Application.ViewModels;
using FluentValidation.Results;
using Equinox.Domain.Interfaces;
using Equinox.Infrastructure.CrossCutting.Notification;

namespace Equinox.Application.Interfaces
{
    /// <summary>
    /// Interface for the Customer App Service, which provides methods for managing customer data.
    /// </summary>
    public interface ICustomerAppService : IDisposable
    {
        /// <summary>
        /// Gets all customer view models in the system.
        /// </summary>
        /// <returns>A task that returns an enumerable collection of customer view models.</returns>
        Task<IEnumerable<CustomerViewModel>> GetAll();

        /// <summary>
        /// Gets a single customer view model by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to retrieve.</param>
        /// <returns>A task that returns a customer view model, or null if no such customer was found.</returns>
        Task<CustomerViewModel> GetById(Guid id);

        /// <summary>
        /// Registers a new customer in the system.
        /// </summary>
        /// <param name="customerViewModel">The customer view model to register.</param>
        /// <returns>A task that returns a validation result object indicating whether the registration was successful or not.</returns>
        Task<ValidationResult> Register(CustomerViewModel customerViewModel);

        /// <summary>
        /// Updates an existing customer in the system.
        /// </summary>
        /// <param name="customerViewModel">The updated customer view model.</param>
        /// <returns>A task that returns a validation result object indicating whether the update was successful or not.</returns>
        Task<ValidationResult> Update(CustomerViewModel customerViewModel);

        /// <summary>
        /// Removes a customer from the system.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to remove.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Remove(Guid id);

        /// <summary>
        /// Adds a customer to the system.
        /// </summary>
        /// <param name="customerViewModel">The customer view model to add.</param>
        /// <returns>A task that returns a validation result object indicating whether the addition was successful or not.</returns>
        Task<ValidationResult> Add(CustomerViewModel customerViewModel);

        /// <summary>
        /// Validates a customer view model.
        /// </summary>
        /// <param name="customerViewModel">The customer view model to validate.</param>
        /// <returns>A task that returns a validation result object indicating whether the view model is valid or not.</returns>
        Task<ValidationResult> Validate(CustomerViewModel customerViewModel);

        /// <summary>
        /// Publishes an event to the system.
        /// </summary>
        /// <param name="domainEvent">The domain event to publish.</param>
        void PublishEvent(IDomainEvent domainEvent);

        /// <summary>
        /// Gets the notification messages.
        /// </summary>
        /// <returns>A list of notification messages.</returns>
        List<NotificationMessage> GetNotificationMessages();

        ///
