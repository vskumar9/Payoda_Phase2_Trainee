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
    public class RentalController : ControllerBase
    {
        private readonly RentalService _rentalService;

        public RentalController(RentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterRental([FromBody] Rental model)
        {
            var result = await _rentalService.RegisterRental(model);
            if (result == "Exist")
                return Conflict("Rental already exists.");
            return CreatedAtAction(nameof(GetRental), new { id = model.RentalId }, model);
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
                return NotFound();
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
    }
}
