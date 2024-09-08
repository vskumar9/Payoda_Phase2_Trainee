using CarRentalService.Exceptions;
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
        private readonly ILogger<CustomersController> _logger;
        private readonly CustomerService _customerService;
        private readonly RentalService _rentalService;
        private readonly ApplicationUtil _appicationUtil;

        public CustomersController(CustomerService customerService, RentalService rentalService, ILogger<CustomersController> logger, ApplicationUtil applicationUtil)
        {
            _customerService = customerService;
            _rentalService = rentalService;
            _logger = logger;
            _appicationUtil = applicationUtil;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterCustomer([FromBody] Customer model)
        {
            try
            {
                model.CustomerId = Guid.NewGuid().ToString();
                _appicationUtil.ValidatePhoneNumber(model.PhoneNumber!);
                _appicationUtil.ValidateEmail(model.Email!);
                _appicationUtil.ValidatePassword(model.PasswordHash);
                var result = await _customerService.RegisterCustomer(model);
                if (result == "Exist")
                    return Conflict("Customer with the same email already exists.");
                return CreatedAtAction(nameof(GetCustomer), new { id = model.CustomerId }, model);
            }
            catch(InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        // GET: api/<CustomersController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customers = await _customerService.GetAllCustomers();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        // GET api/customer/{id}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetCustomer(string id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        // PUT api/customer/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateCustomer(string id, [FromBody] Customer model)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        // DELETE api/customer/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        // GET api/customer/rental-history
        [HttpGet("rental-history")]
        [Authorize]
        public async Task<IActionResult> GetRentalHistory()
        {
            try
            {
                var customerId = User.FindFirstValue(ClaimTypes.PrimarySid);
                if (string.IsNullOrEmpty(customerId))
                    return Unauthorized("Invalid token.");

                var rentals = await _rentalService.GetRentalHistory(customerId);
                if (rentals == null || !rentals.Any())
                    return NotFound("No rental history found.");

                return Ok(rentals);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpGet("Filter/Any")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetCustomersAny(string? customerId = null, string? firstName = null, string? lastName = null, string? email = null, string? phoneNumber = null, string? sortBy = "FirstName", bool sortDescending = false)
        {
            try
            {
                var customers = await _customerService.GetCustomersAny(customerId, firstName, lastName, email, phoneNumber, sortBy, sortDescending);
                if (customers == null || !customers.Any()) return Ok("No Data Match.");
                return Ok(customers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpGet("Count")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetTotalCustomers()
        {
            try
            {
                return Ok(await _customerService.GetTotalCustomers());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }


    }
}
