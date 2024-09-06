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

        private readonly TokenService _tokenService;
        private readonly CarRentalDbContext _context;

        public TokenController(TokenService tokenService, CarRentalDbContext context)
        {
            _tokenService = tokenService;
            _context = context;
        }

        //[HttpPost("register/customer")]

        //[HttpPost("register/admin")]

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var customer = await _tokenService.ValidateCustomerAsync(model.Email, model.Password);
            if (customer != null)
            {
                var token = await _tokenService.GenerateTokenAsync(customer);
                return Ok(new { Token = token });
            }

            var admin = await _tokenService.ValidateAdminAsync(model.Email, model.Password);
            if (admin != null)
            {
                var token = await _tokenService.GenerateAdminTokenAsync(admin);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials.");
        }

    }
}
