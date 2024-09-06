using CarRentalService.Interface;
using CarRentalService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalService.Repository
{
    public class AdminRepository : IAdmin
    {
        private readonly CarRentalDbContext _context;

        public AdminRepository(CarRentalDbContext context)
        {
            _context = context;
        }
        public async Task<string> RegisterAdmin(Admin model)
        {
            if (await _context.Admins.AnyAsync(a => a.Email == model.Email && a.Username == model.Username))
            {
                return "Exist";
            }

            var admin = new Admin
            {
                AdminId = Guid.NewGuid().ToString(),
                Username = model.Username,
                FullName = model.FullName,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash)
            };

            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();

            return "Added";
        }
    }
}
