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
            if(model == null) throw new ArgumentNullException(nameof(model));
            return await _customer.RegisterCustomer(model);
        }
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _customer.GetAllCustomers();
        }

        public async Task<Customer> GetCustomer(string id)
        {
            if (id == null) throw new ArgumentNullException();
            return await _customer.GetCustomer(id);
        }

        public async Task<Customer> UpdateCustomer(Customer model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            return await _customer.UpdateCustomer(model);
        }

        public async Task<string> DeleteCustomer(Customer model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            return await _customer.DeleteCustomer(model);
        }
    }
}
