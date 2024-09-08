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
            try
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
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {
                return await _context.Customers.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Customer> GetCustomer(string id)
        {
            try
            {
                return await _context.Customers.FindAsync(id) ?? throw new NullReferenceException();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Customer> UpdateCustomer(Customer model)
        {
            try
            {
                var customer = await _context.Customers.FindAsync(model.CustomerId);
                if (customer == null)
                {
                    return null!;
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
            catch
            {
                throw;
            }
        }

        public async Task<string> DeleteCustomer(Customer model)
        {
            try
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
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersAny(string? customerId = null, string? firstName = null, string? lastName = null, string? email = null,  string? phoneNumber = null, string? sortBy = "FirstName", bool sortDescending = false)
        {
            try
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

                query = sortDescending ? ApplySorting(query, sortBy!, true) : ApplySorting(query, sortBy!, false);

                return await query.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> GetTotalCustomers()
        {
            try
            {
                return await _context.Customers.CountAsync();
            }
            catch
            {
                throw;
            }
        }

        private IQueryable<Customer> ApplySorting(IQueryable<Customer> query, string sortBy, bool descending)
        {
            return sortBy.ToLower() switch
            {
                "customerid" => descending ? query.OrderByDescending(c => c.CustomerId) : query.OrderBy(c => c.CustomerId),
                "firstname" => descending ? query.OrderByDescending(c => c.FirstName) : query.OrderBy(c => c.FirstName),
                "lastname" => descending ? query.OrderByDescending(c => c.LastName) : query.OrderBy(c => c.LastName),
                "email" => descending ? query.OrderByDescending(c => c.Email) : query.OrderBy(c => c.Email),
                "phonenumber" => descending ? query.OrderByDescending(c => c.PhoneNumber) : query.OrderBy(c => c.PhoneNumber),
                _ => descending ? query.OrderByDescending(c => c.FirstName) : query.OrderBy(c => c.FirstName),
            };
        }
    }
}
