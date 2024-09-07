using CarRentalService.Interface;
using CarRentalService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
                CustomerId = model.CustomerId,
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

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(string id)
        {
            return await _context.Customers.FindAsync(id) ?? throw new NullReferenceException();
        }

        public async Task<Customer> UpdateCustomer(Customer model)
        {
            var customer = await _context.Customers.FindAsync(model.CustomerId);
            if (customer == null)
            {
                return null;
            }

            //_context.Entry(model).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Email = model.Email;
            customer.PhoneNumber = model.PhoneNumber;
            customer.DateOfBirth = model.DateOfBirth;
            customer.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.PasswordHash);

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<string> DeleteCustomer(Customer model)
        {
            var customer = await _context.Customers.FindAsync(model.CustomerId);
            if (customer == null)
            {
                return "NotFound";
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return "Deleted";
        }

        public async Task<IEnumerable<Customer>> GetCustomersAny(string? customerId = null, string? firstName = null, string? lastName = null, string? email = null, string? phoneNumber = null)
        {
            var query = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(customerId))
            {
                query = query.Where(c => c.CustomerId == customerId);
            }

            if (!string.IsNullOrEmpty(firstName))
            {
                var lowerFirstName = firstName.ToLower();
                query = query.Where(c => c.FirstName.ToLower().Contains(lowerFirstName));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                var lowerLastName = lastName.ToLower();
                query = query.Where(c => c.LastName.ToLower().Contains(lowerLastName));
            }

            if (!string.IsNullOrEmpty(email))
            {
                var lowerEmail = email.ToLower();
                query = query.Where(c => c.Email.ToLower().Contains(lowerEmail));
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                var lowerPhoneNumber = phoneNumber.ToLower();
                query = query.Where(c => c.PhoneNumber != null && c.PhoneNumber.ToLower().Contains(lowerPhoneNumber));
            }
            return await query.ToListAsync();
        }
    }
}
