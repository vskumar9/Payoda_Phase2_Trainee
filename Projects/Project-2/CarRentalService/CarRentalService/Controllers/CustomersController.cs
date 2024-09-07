using CarRentalService.Models;
using CarRentalService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly RentalService _rentalService;

        public CustomersController(CustomerService customerService, RentalService rentalService)
        {
            _customerService = customerService;
            _rentalService = rentalService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer([FromBody] Customer model)
        {
            var result = await _customerService.RegisterCustomer(model);
            if (result == "Exist")
                return Conflict("Customer with the same email already exists.");
            return CreatedAtAction(nameof(GetCustomer), new { id = model.CustomerId }, model);
        }

        // GET: api/<CustomersController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        // GET api/customer/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetCustomer(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.PrimarySid);
            var isAdmin = User.IsInRole("Admin");
            if (id != userId && !isAdmin)
                return Forbid("You are not authorized to access this data.");

            var customer = await _customerService.GetCustomer(id);
            if (customer == null)
                return NotFound("Customer not found.");

            return Ok(customer);
        }

        // PUT api/customer/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateCustomer(string id, [FromBody] Customer model)
        {
            var userId = User.FindFirstValue(ClaimTypes.PrimarySid);
            var isAdmin = User.IsInRole("Admin");

            if (id != userId && !isAdmin)
                return Forbid("You are not authorized to update this data.");

            if (model == null)
                return BadRequest("Customer model cannot be null.");

            if (id != model.CustomerId)
                return BadRequest("Customer ID mismatch.");

            var updatedCustomer = await _customerService.UpdateCustomer(model);
            if (updatedCustomer == null)
                return NotFound("Customer not found.");

            return Ok(updatedCustomer);
        }

        // DELETE api/customer/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.PrimarySid);
            var isAdmin = User.IsInRole("Admin");

            if (id != userId && !isAdmin)
                return Forbid("You are not authorized to delete this data.");

            var customer = await _customerService.GetCustomer(id);
            if (customer == null)
                return NotFound("Customer not found.");

            var result = await _customerService.DeleteCustomer(customer);
            if (result == "NotFound")
                return NotFound("Customer not found.");

            return NoContent();
        }

        // GET api/customer/rental-history
        [HttpGet("rental-history")]
        [Authorize]
        public async Task<IActionResult> GetRentalHistory()
        {
            var customerId = User.FindFirstValue(ClaimTypes.PrimarySid);
            if (string.IsNullOrEmpty(customerId))
                return Unauthorized("Invalid token.");

            var rentals = await _rentalService.GetRentalHistory(customerId);
            if (rentals == null || !rentals.Any())
                return NotFound("No rental history found.");

            return Ok(rentals);
        }
    }
}
