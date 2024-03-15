using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Equinox.Application.EventSourcedNormalizers; // Namespace for event sourced normalizers
using Equinox.Application.Interfaces; // Namespace for application interfaces
using Equinox.Application.ViewModels; // Namespace for view models
using Microsoft.AspNetCore.Authorization; // Namespace for authorization attributes
using Microsoft.AspNetCore.Mvc; // Namespace for MVC attributes
using NetDevPack.Identity.Authorization; // Namespace for custom authorization

namespace Equinox.Services.Api.Controllers // Namespace for API controllers
{
    [Authorize] // Authorize all actions in this controller
    public class CustomerController : ApiController // Base class for API controllers
    {
        private readonly ICustomerAppService _customerAppService; // Customer app service instance

        public CustomerController(ICustomerAppService customerAppService) // Constructor
        {
            _customerAppService = customerAppService; // Initialize the customer app service
        }

        [AllowAnonymous] // Allow anonymous access to this action
        [HttpGet("customer-management")] // Map to GET /customer-management
        public async Task<IEnumerable<CustomerViewModel>> Get() // Action for getting all customers
        {
            return await _customerAppService.GetAll(); // Return all customers from the app service
        }

        [AllowAnonymous] // Allow anonymous access to this action
        [HttpGet("customer-management/{id:guid}")] // Map to GET /customer-management/{id}
        public async Task<CustomerViewModel> Get(Guid id) // Action for getting a customer by ID
        {
            return await _customerAppService.GetById(id); // Return the customer with the given ID from the app service
        }

        [CustomAuthorize("Customers", "Write")] // Custom authorization attribute for write access to customers
        [HttpPost("customer-management")] // Map to POST /customer-management
        public async Task<IActionResult> Post([FromBody]CustomerViewModel customerViewModel) // Action for creating a new customer
        {
            if (!ModelState.IsValid) // If the model state is not valid
            {
                return CustomResponse(ModelState); // Return a custom response with the model state errors
            }

            return CustomResponse(await _customerAppService.Register(customerViewModel)); // Otherwise, register the new customer and return the result
        }

        [CustomAuthorize("Customers", "Write")] // Custom authorization attribute for write access to customers
        [HttpPut("customer-management")] // Map to PUT /customer-management
        public async Task<IActionResult> Put([FromBody]CustomerViewModel customerViewModel) // Action for updating a customer
        {
            if (!ModelState.IsValid) // If the model state is not valid
            {
                return CustomResponse(ModelState); // Return a custom response with the model state errors
            }

            return CustomResponse(await _customerAppService.Update(customerViewModel)); // Otherwise, update the customer and return the result
        }

        [CustomAuthorize("Customers", "Remove")] // Custom authorization attribute for remove access to customers
        [HttpDelete("customer-management")] // Map to DELETE /customer-management
        public async Task<IActionResult> Delete(Guid id) // Action for deleting a customer
        {
            return CustomResponse(await _customerAppService.Remove(id)); // Delete the customer with the given ID and return the result
        }

        [AllowAnonymous] // Allow anonymous access to this action
        [HttpGet("customer-management/history/{id:guid}")] // Map to GET /customer-management/history/{id}
        public async Task<IList<CustomerHistoryData>> History(Guid id) // Action for getting the
