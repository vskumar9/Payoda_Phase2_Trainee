using CarRentalService.Interface;
using CarRentalService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalService.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly CarRentalDbContext _context;

        public CustomerRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public async Task<string> RegisterCustomer(Customer model)
        {
            if (await _context.Customers.AnyAsync(c => c.Email == model.Email))
            {
                return "Exist";
            }

            var customer = new Customer
            {
                CustomerId = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                DateOfBirth = model.DateOfBirth,
                RegistrationDate = DateTime.UtcNow,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash)
            };

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return "Added";
        }
    }
}
