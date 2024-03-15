using System;
using System.Threading.Tasks;
using Equinox.Application.Interfaces; // Interface for CustomerAppService
using Equinox.Application.ViewModels; // ViewModels for Customer
using Microsoft.AspNetCore.Authorization; // For authorization attributes
using Microsoft.AspNetCore.Mvc; // For controller and action results
using NetDevPack.Identity.Authorization; // For custom authorization attributes

namespace Equinox.UI.Web.Controllers // Equinox UI Web Controllers namespace
{
    [Authorize] // Authorize all actions in this controller
    public class CustomerController : BaseController // Inherits from BaseController
    {
        private readonly ICustomerAppService _customerAppService; // CustomerAppService instance

        public CustomerController(ICustomerAppService customerAppService) // Constructor
        {
            _customerAppService = customerAppService; // Inject ICustomerAppService
        }

        [AllowAnonymous] // Allow anonymous access
        [HttpGet("customer-management/list-all")]
        public async Task<IActionResult> Index() // Index action
        {
            var customers = await _customerAppService.GetAll(); // Get all customers
            return View(customers); // Return the view with customers
        }

        [AllowAnonymous] // Allow anonymous access
        [HttpGet("customer-management/customer-details/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id) // Details action
        {
            if (id == null) return NotFound(); // If id is null, return 404

            var customerViewModel = await _customerAppService.GetById(id.Value); // Get customer by id

            if (customerViewModel == null) return NotFound(); // If customer is null, return 404

            return View(customerViewModel); // Return the view with customer
        }

        [CustomAuthorize("Customers", "Write")] // Custom authorization attribute
        [HttpGet("customer-management/register-new")]
        public IActionResult Create() // Create action
        {
            return View(); // Return the create view
        }

        [CustomAuthorize("Customers", "Write")] // Custom authorization attribute
        [HttpPost("customer-management/register-new")]
        public async Task<IActionResult> Create(CustomerViewModel customerViewModel) // Create action
        {
            if (!ModelState.IsValid) return View(customerViewModel); // If model state is not valid, return the view with customerViewModel

            if (ResponseHasErrors(await _customerAppService.Register(customerViewModel)))
                return View(customerViewModel); // If there are errors during registration, return the view with customerViewModel

            ViewBag.Sucesso = "Customer Registered!"; // Set success message

            return View(customerViewModel); // Return the view with customerViewModel
        }

        [CustomAuthorize("Customers", "Write")] // Custom authorization attribute
        [HttpGet("customer-management/edit-customer/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id) // Edit action
        {
            if (id == null) return NotFound(); // If id is null, return 404

            var customerViewModel = await _customerAppService.GetById(id.Value); // Get customer by id

            if (customerViewModel == null) return NotFound(); // If customer is null, return 404

            return View(customerViewModel); // Return the view with customerViewModel
        }

        [CustomAuthorize("Customers", "Write")] // Custom authorization attribute
        [HttpPost("customer-management/edit-customer/{id:guid}")]
        public async Task<IActionResult> Edit(CustomerViewModel customerViewModel) // Edit action
        {
            if (!ModelState.IsValid) return View(customerViewModel); // If model state is not valid, return the view with customerViewModel

            if (ResponseHasErrors(await _customerAppService.Update(customerViewModel)))
                return View(customerViewModel); // If there are errors during update, return the view with customerViewModel

            ViewBag.Sucesso = "Customer Updated!"; // Set success message

            return View(customerViewModel); // Return the view with customerViewModel
        }

        [CustomAuthorize("Customers", "Remove")] // Custom authorization attribute
        [HttpGet("customer-management/remove-customer/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id) // Delete action
        {
            if (id == null) return NotFound(); // If id is null, return 404

            var customerViewModel = await _customerAppService.GetById(id.Value); // Get customer by id

            if (customerViewModel == null) return NotFound(); // If customer is null, return 404

            return View(customerViewModel); // Return the view with customerViewModel
        }

        [CustomAuthorize("Customers", "Remove")] // Custom authorization attribute
        [HttpPost("customer-management/remove-customer/{id:guid}"), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id) // DeleteConfirmed action
        {
            if (ResponseHasErrors(await _customerAppService.Remove(id)))
                return View(await _customerAppService.GetById(id)); // If there are errors during delete, return the view with customerViewModel

            ViewBag.Sucesso = "Customer Removed!"; // Set success message
            return RedirectToAction("Index"); // Redirect to Index action
        }

        [AllowAnonymous] // Allow anonymous access
        [HttpGet("customer-management/customer-history/{id:guid}")]
        public async Task<JsonResult> History(Guid id) // History action
        {
            var customerHistoryData = await _customerAppService.GetAllHistory(id); // Get all customer history
            return Json(customerHistoryData); // Return Json result with customer history data
        }
    }
}
