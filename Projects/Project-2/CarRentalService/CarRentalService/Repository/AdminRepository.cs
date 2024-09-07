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

        public async Task<string> DeleteAdmin(Admin model)
        {
            var admin = await _context.Admins.FindAsync(model.AdminId);
            if (admin == null)
            {
                return "NotFound";
            }

            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();

            return "Deleted";
        }

        public async Task<Admin> GetAdmin(string id)
        {
            return await _context.Admins.FindAsync(id) ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<Admin>> GetAdminsAny(string? adminId = null, string? username = null, string? email = null, string? fullName = null)
        {
            var query = _context.Admins.AsQueryable();

            if (!string.IsNullOrEmpty(adminId))
            {
                query = query.Where(a => a.AdminId == adminId);
            }

            if (!string.IsNullOrEmpty(username))
            {
                var lowerUsername = username.ToLower();
                query = query.Where(a => a.Username.ToLower().Contains(lowerUsername));
            }

            if (!string.IsNullOrEmpty(email))
            {
                var lowerEmail = email.ToLower();
                query = query.Where(a => a.Email.ToLower().Contains(lowerEmail));
            }

            if (!string.IsNullOrEmpty(fullName))
            {
                var lowerFullName = fullName.ToLower();
                query = query.Where(a =>
                    (a.Username.ToLower().Contains(lowerFullName)) ||
                    (a.Email.ToLower().Contains(lowerFullName)));
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<string> RegisterAdmin(Admin model)
        {
            if (await _context.Admins.AnyAsync(a => a.Email == model.Email && a.Username == model.Username))
            {
                return "Exist";
            }

            var admin = new Admin
            {
                AdminId = model.AdminId,
                Username = model.Username,
                FullName = model.FullName,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash),
                CreatedDate = DateTime.UtcNow
            };

            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();

            return "Added";
        }

        public async Task<Admin> UpdateAdmin(Admin model)
        {
            var admin = await _context.Admins.FindAsync(model.AdminId);
            if (admin == null)
            {
                return null!;
            }

            //_context.Entry(model).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            admin.Username = model.Username;
            admin.FullName = model.FullName;
            admin.Email = model.Email;
            admin.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);

            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();

            return admin;
        }
    }
}
