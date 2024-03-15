using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Equinox.Application.EventSourcedNormalizers;
using Equinox.Application.ViewModels;
using FluentValidation.Results;

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
        /// <returns>A task
