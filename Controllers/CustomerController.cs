using Buisness.Services;
using Buisness.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.ConsoleApp.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerRegistrationForm form)
        {
            if (form == null || string.IsNullOrWhiteSpace(form.CustomerName))
            {
                return BadRequest("Invalid customer data.");
            }

            await _customerService.CreateCustomerAsync(form);
            return CreatedAtAction(nameof(GetCustomerById), new { id = form.CustomerName }, form);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            return Ok(customer);
        }

        [HttpGet("name/{customerName}")]
        public async Task<IActionResult> GetCustomerByName(string customerName)
        {
            var customer = await _customerService.GetCustomerByCustomerNameAsync(customerName);
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            if (updatedCustomer == null || string.IsNullOrWhiteSpace(updatedCustomer.CustomerName))
            {
                return BadRequest("Invalid customer data.");
            }

            updatedCustomer.Id = id;
            var success = await _customerService.UpdateCustomerAsync(updatedCustomer);
            if (!success)
            {
                return NotFound("Customer not found.");
            }

            return Ok("Customer updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var success = await _customerService.DeleteCustomerAsync(id);
            if (!success)
            {
                return NotFound("Customer not found.");
            }

            return Ok("Customer deleted successfully!");
        }
    }
}
