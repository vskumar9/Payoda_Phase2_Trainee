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
        private readonly VehicleService _vehicleService;

        public VehicleController(VehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterVehicle([FromBody] Vehicle model)
        {
            var result = await _vehicleService.RegisterVehicle(model);
            if (result == "Exist")
                return Conflict("Vehicle already exists.");
            return CreatedAtAction(nameof(GetVehicle), new { id = model.VehicleId }, model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            var vehicles = await _vehicleService.GetAllVehicles();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(string id)
        {
            var vehicle = await _vehicleService.GetVehicle(id);
            if (vehicle == null)
                return NotFound();
            return Ok(vehicle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(string id, [FromBody] Vehicle model)
        {
            if (id != model.VehicleId)
                return BadRequest("Vehicle ID mismatch.");

            var updatedVehicle = await _vehicleService.UpdateVehicle(model);
            if (updatedVehicle == null)
                return NotFound();
            return Ok(updatedVehicle);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(string id)
        {
            var vehicle = await _vehicleService.GetVehicle(id);
            if (vehicle == null)
                return NotFound();

            var result = await _vehicleService.DeleteVehicle(vehicle);
            if (result == "NotFound")
                return NotFound();
            return NoContent();
        }
    }
}
