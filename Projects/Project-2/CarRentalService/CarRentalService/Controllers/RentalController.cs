using CarRentalService.Models;
using CarRentalService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace CarRentalService.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly ILogger<RentalController> _logger;
        private readonly RentalService _rentalService;
        private readonly CustomerService _customerService;
        private readonly VehicleService _vehicleService;

        public RentalController(ILogger<RentalController> logger, RentalService rentalService, CustomerService customerService, VehicleService vehicleService)
        {
            _logger = logger;
            _rentalService = rentalService;
            _customerService = customerService;
            _vehicleService = vehicleService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterRental([FromBody] Rental model)
        {
            try
            {
                //if(_customerService.GetCustomerById(model.CustomerId) == null || _vehicleService.GetVehicleById(model.VehicleId) == null) return BadRequest("Customer or Vehical not registered..!");
                model.RentalId = Guid.NewGuid().ToString();
                var result = await _rentalService.RegisterRental(model);
                if (result.Contains("Vehicle or Customer Not found.")) return Conflict("Vehicle or Customer Not found.");
                if (result.Contains("Vehicle Rentaled.")) return Conflict("Vehicle Rentaled.");
                if (result.Contains("Rnetal date or return date wrong!")) return Conflict("Rnetal date or return date wrong!");
                return CreatedAtAction(nameof(GetRental), new { id = model.RentalId }, model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRentals()
        {
            var rentals = await _rentalService.GetAllRentals();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRental(string id)
        {

            var rental = await _rentalService.GetRental(id);
            if (rental == null)
                return NotFound();
            return Ok(rental);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRental(string id, [FromBody] Rental model)
        {
            if (id != model.RentalId)
                return BadRequest("Rental ID mismatch.");

            var updatedRental = await _rentalService.UpdateRental(model);
            if (updatedRental == null)
                return Ok("Vehicle/Customer not found. rental date mistake or Vehicle Already Rentaled.");
            return Ok(updatedRental);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(string id)
        {
            var rental = await _rentalService.GetRental(id);
            if (rental == null)
                return NotFound();

            var result = await _rentalService.DeleteRental(rental);
            if (result == "NotFound")
                return NotFound();
            return NoContent();
        }

        [HttpGet("Filter")]
        public async Task<IActionResult> GetRentalsByDate([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            var rental = await _rentalService.GetRentalsByDateRangeAsync(startDate, endDate);
            if (rental == null) return Ok("Not Available Rental data.");
            return Ok(rental);
        }

        [HttpGet("Filter/Any")]
        public async Task<IActionResult> GetRentalsAny(string? firstName = null, string? lastName = null, string? vehicleName = null, string? customerId = null, string? email = null, string? phoneNumber = null, string? vehicleId = null)
        {
            var rental = await _rentalService.GetRentalsAny(firstName, lastName, vehicleName, customerId, email, phoneNumber, vehicleId);
            if (rental == null) return Ok("No Rentals.");
            return Ok(rental);
        }

    }
}
