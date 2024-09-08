using CarRentalService.Models;
using CarRentalService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> _logger;
        private readonly TokenService _tokenService;
        private readonly CarRentalDbContext _context;

        public TokenController(TokenService tokenService, CarRentalDbContext context, ILogger<TokenController> logger)
        {
            _tokenService = tokenService;
            _context = context;
            _logger = logger;
        }

        //[HttpPost("register/customer")]

        //[HttpPost("register/admin")]

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            try
            {

                var customer = await _tokenService.ValidateCustomerAsync(model.Email, model.Password);
                if (customer != null)
                {
                    var token = await _tokenService.GenerateTokenAsync(customer);
                    customer.LastLoginDate = DateTime.UtcNow;
                    _context.Entry(customer).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok(new { Token = token });
                }

                var admin = await _tokenService.ValidateAdminAsync(model.Email, model.Password);
                if (admin != null)
                {
                    var token = await _tokenService.GenerateAdminTokenAsync(admin);
                    admin.LastLoginDate = DateTime.Now;
                    _context.Entry(admin).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return Ok(new { Token = token });
                }

                return Unauthorized("Invalid credentials.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering the rental.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
            }
        }

    }
}
