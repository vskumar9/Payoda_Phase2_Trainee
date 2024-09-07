using CarRentalService.Models;
using CarRentalService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRentalService.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAdmin([FromBody] Admin model)
        {
            model.AdminId = Guid.NewGuid().ToString();
            var result = await _adminService.RegisterAdmin(model);
            if (result == "Exist")
                return Conflict("Admin with the same email or username already exists.");
            return CreatedAtAction(nameof(GetAdmin), new { id = model.AdminId }, model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAdmins();
            return Ok(admins);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin(string id)
        {
            var admin = await _adminService.GetAdmin(id);
            if (admin == null)
                return NotFound();
            return Ok(admin);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(string id, [FromBody] Admin model)
        {
            if (id != model.AdminId)
                return BadRequest("Admin ID mismatch.");

            var updatedAdmin = await _adminService.UpdateAdmin(model);
            if (updatedAdmin == null)
                return NotFound();
            return Ok(updatedAdmin);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(string id)
        {
            var admin = await _adminService.GetAdmin(id);
            if (admin == null)
                return NotFound();

            var result = await _adminService.DeleteAdmin(admin);
            if (result == "NotFound")
                return NotFound();
            return NoContent();
        }

        [HttpGet("Filter/Any")]
        public async Task<IActionResult> GetAdminsAny(string? adminId = null, string? username = null, string? email = null, string? fullName = null)
        {
            var admin = await _adminService.GetAdminsAny(adminId, username, email, fullName);
            if (admin == null) return Ok("No Data Match.");
            return Ok(admin);
        }

    }
}

