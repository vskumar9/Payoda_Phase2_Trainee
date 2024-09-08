using CarRentalService.Interface;
using CarRentalService.Models;
using CarRentalService.Repository;

namespace CarRentalService.Services
{
    public class CustomerService
    {
        private readonly ICustomer _customer;
        public CustomerService(ICustomer customer)
        {
            _customer = customer;
        }

        public async Task<string> RegisterCustomer(Customer model)
        {
            try
            {
                return await _customer.RegisterCustomer(model);
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
                return await _customer.GetAllCustomers();
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
                return await _customer.GetCustomer(id);
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
                return await _customer.UpdateCustomer(model);
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
                return await _customer.DeleteCustomer(model);
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<Customer> GetCustomerById(string id)
        {
            try
            {
                var customer = await _customer.GetCustomer(id);
                if (customer == null) return null!;
                return customer;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetCustomersAny(string? customerId = null, string? firstName = null, string? lastName = null, string? email = null, string? phoneNumber = null, string? sortBy = "FirstName", bool sortDescending = false)
        {
            try
            {
                var customer = await _customer.GetCustomersAny(customerId, firstName, lastName, email, phoneNumber, sortBy, sortDescending);
                if(customer == null) return Enumerable.Empty<Customer>();
                return customer;
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
                return await _customer.GetTotalCustomers();
            }
            catch
            {
                throw;
            }
        }



    }
}
