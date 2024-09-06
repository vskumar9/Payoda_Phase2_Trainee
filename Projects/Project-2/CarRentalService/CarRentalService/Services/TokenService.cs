using CarRentalService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace CarRentalService.Services
{
    public class TokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly CarRentalDbContext _context;

        public TokenService(IConfiguration configuration, CarRentalDbContext context)
        {
            _key = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(configuration["Key"]!));
            _context = context;
        }

        public async Task<string> GenerateTokenAsync(Customer user)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Name, user.FirstName),
            new Claim(ClaimTypes.Role, "User")
        };

            return await GenerateTokenAsync(claims);
        }

        public async Task<string> GenerateAdminTokenAsync(Admin admin)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, admin.Email),
            new Claim(JwtRegisteredClaimNames.Name, admin.FullName),
            new Claim(ClaimTypes.Role, "Admin")
        };

            return await GenerateTokenAsync(claims);
        }

        private async Task<string> GenerateTokenAsync(IEnumerable<Claim> claims)
        {
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<Customer?> ValidateCustomerAsync(string email, string password)
        {
            var user = await _context.Customers
                .SingleOrDefaultAsync(c => c.Email == email);

            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }

            return null;
        }

        public async Task<Admin?> ValidateAdminAsync(string email, string password)
        {
            var admin = await _context.Admins
                .SingleOrDefaultAsync(a => a.Email == email);

            if (admin != null && BCrypt.Net.BCrypt.Verify(password, admin.PasswordHash))
            {
                return admin;
            }

            return null;
        }
    }
}
