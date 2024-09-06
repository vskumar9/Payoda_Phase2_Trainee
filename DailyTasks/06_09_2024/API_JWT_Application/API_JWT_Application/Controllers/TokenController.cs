using API_JWT_Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_JWT_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly SymmetricSecurityKey _key;
        private readonly API_JWT_DbContext _con;

        // Static admin credentials
        private const string AdminUsername = "admin";
        private const string AdminPassword = "admin123";

        public TokenController(IConfiguration configuration, API_JWT_DbContext con)
        {
            _key = new SymmetricSecurityKey(UTF8Encoding.UTF8.GetBytes(configuration["Key"]!));
            _con = con;
        }
        [HttpPost]
        public string GenerateToken(Users user)
        {
            string token = string.Empty;

            // Static sign-in check for admin
            if (user.UserName == AdminUsername && user.Password == AdminPassword)
            {
                token = GenerateAdminToken();
            }

            else
            {
                // Define the role required for token generation (e.g., "Admin" for regular users)
                string requiredRole = "User"; // Adjust the required role as needed


                if (ValidateUser(user.UserEmail, user.Password, requiredRole))
                {

                    var claims = new List<Claim>
                  {
                      new Claim(JwtRegisteredClaimNames.NameId,user.UserName!),
                      new Claim(JwtRegisteredClaimNames.Email,user.UserEmail)

                  };
                    var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
                    var tokenDescription = new SecurityTokenDescriptor
                    {
                        SigningCredentials = cred,
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.Now.AddMinutes(2)
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var createToken = tokenHandler.CreateToken(tokenDescription);
                    token = tokenHandler.WriteToken(createToken);
                    return token;
                }
                else
                {
                    return string.Empty;
                }
            }
            return token;
        }

        // Static token generation for admin
        private string GenerateAdminToken()
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, AdminUsername),
            new Claim(JwtRegisteredClaimNames.Email, "admin@domain.com"), // Static admin email
            new Claim(ClaimTypes.Role, "Admin") // Admin role
        };

            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var tokenDescription = new SecurityTokenDescriptor
            {
                SigningCredentials = cred,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(2)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createToken = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(createToken);
        }


        private bool ValidateUser(string email, string password, string requiredRole)
        {
            var users = _con.Users.ToList();
            var user = users.FirstOrDefault(u => u.UserEmail == email && u.Password == password);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
