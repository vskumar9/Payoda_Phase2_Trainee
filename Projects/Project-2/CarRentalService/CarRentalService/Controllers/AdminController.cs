using CarRentalService.Exceptions;
using CarRentalService.Interface;
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
        private readonly ILogger<AdminController> _logger;
        private readonly AdminService _adminService;
        private readonly ApplicationUtil _applicationUtil;

        public AdminController(AdminService adminService, ILogger<AdminController> logger, ApplicationUtil applicationUtil)
        {
            _adminService = adminService;
            _logger = logger;
            _applicationUtil = applicationUtil;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAdmin([FromBody] Admin model)
        {
            try
            {
                model.AdminId = Guid.NewGuid().ToString();
                _applicationUtil.ValidateEmail(model.Email);
                _applicationUtil.ValidatePassword(model.PasswordHash);
                var result = await _adminService.RegisterAdmin(model);
                if (result.Contains("Invalid admin")) return Conflict("Invalid admin");
                if (result == "Exist") return Conflict("Admin with the same email or username already exists.");
                return CreatedAtAction(nameof(GetAdmin), new { id = model.AdminId }, model);
            }
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdmins()
        {
            try
            {
                var admins = await _adminService.GetAllAdmins();
                return Ok(admins);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin(string id)
        {
            try
            {
                var admin = await _adminService.GetAdmin(id);
                if (admin == null)
                    return NotFound();
                return Ok(admin);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdmin(string id, [FromBody] Admin model)
        {
            try
            {
                if (id != model.AdminId)
                    return BadRequest("Admin ID mismatch.");

                _applicationUtil.ValidateEmail(model.Email);
                _applicationUtil.ValidatePassword(model.PasswordHash);
                var updatedAdmin = await _adminService.UpdateAdmin(model);
                if (updatedAdmin == null)
                    return NotFound();
                return Ok(updatedAdmin);
            }
            catch (InvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(string id)
        {
            try
            {
                var admin = await _adminService.GetAdmin(id);
                if (admin == null)
                    return NotFound();

                var result = await _adminService.DeleteAdmin(admin);
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
        public async Task<IActionResult> GetAdminsAny(string? adminId = null, string? username = null, string? email = null, string? fullName = null, string? sortBy = "Username", bool sortDescending = false)
        {
            try
            {
                var admin = await _adminService.GetAdminsAny(adminId, username, email, fullName, sortBy, sortDescending);
                if (admin == null || !admin.Any()) return Ok("No Data Match.");
                return Ok(admin);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

        [HttpGet("Count")]
        public async Task<IActionResult> GetTotalAdmins()
        {
            try
            {
                return Ok(await _adminService.GetTotalAdmins());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }



    }
}

