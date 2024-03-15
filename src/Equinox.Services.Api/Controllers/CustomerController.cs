using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Equinox.Application.EventSourcedNormalizers;
using Equinox.Application.Interfaces;
using Equinox.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;

namespace Equinox.Services.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerViewModel>> GetById(Guid id)
        {
            var customer = await _customerAppService.GetById(id);
            return Ok(customer);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerViewModel>>> GetAll()
        {
            var customers = await _customerAppService.GetAll();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerViewModel>> Post([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _customerAppService.Register(customerViewModel);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }

        [HttpPut]
        public async Task<ActionResult<CustomerViewModel>> Put([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _customerAppService.Update(customerViewModel);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _customerAppService.Remove(id);
            return NoContent();
        }

        [HttpGet("{id}/history")]
        public async Task<ActionResult<IEnumerable<CustomerHistoryData>>> GetHistory(Guid id)
        {
            var history = await _customerAppService.GetCustomerHistory(id);
            return Ok(history);
        }
    }
}
