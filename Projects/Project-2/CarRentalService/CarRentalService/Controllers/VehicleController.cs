using CarRentalService.Models;
using CarRentalService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalService.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> _logger;
        private readonly VehicleService _vehicleService;

        public VehicleController(VehicleService vehicleService, ILogger<VehicleController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterVehicle([FromBody] Vehicle model)
        {
            try
            {
                model.VehicleId = Guid.NewGuid().ToString();
                var result = await _vehicleService.RegisterVehicle(model);
                if (result == "Exist")
                    return Conflict("Vehicle already exists.");
                return CreatedAtAction(nameof(GetVehicle), new { id = model.VehicleId }, model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            try
            {
                var vehicles = await _vehicleService.GetAllVehicles();
                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(string id)
        {
            try
            {
                var vehicle = await _vehicleService.GetVehicle(id);
                if (vehicle == null)
                    return NotFound();
                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(string id, [FromBody] Vehicle model)
        {
            try
            {
                if (id != model.VehicleId)
                    return BadRequest("Vehicle ID mismatch.");

                var updatedVehicle = await _vehicleService.UpdateVehicle(model);
                if (updatedVehicle == null)
                    return NotFound();
                return Ok(updatedVehicle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(string id)
        {
            try
            {
                var vehicle = await _vehicleService.GetVehicle(id);
                if (vehicle == null)
                    return NotFound();

                var result = await _vehicleService.DeleteVehicle(vehicle);
                if (result == "NotFound")
                    return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpGet("Filter/Any")]
        public async Task<IActionResult> GetVehiclesAny(string? vehicleId = null, string? make = null, string? model = null, int? year = null, string? color = null)
        {
            try
            {
                var vehicle = await _vehicleService.GetVehiclesAny(vehicleId, make, model, year, color);
                if (vehicle == null) return Ok("No Vehicles.");
                return Ok(vehicle);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpGet("Count")]
        public async Task<IActionResult> GetTotalVehicles()
        {
            try
            {
                return Ok(await _vehicleService.GetTotalVehicles());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }


    }
}
