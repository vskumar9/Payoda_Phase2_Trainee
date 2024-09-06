using CarRentalService.Interface;
using CarRentalService.Models;

namespace CarRentalService.Services
{
    public class CustomerService
    {
        private readonly ICustomer _customer;
        public CustomerService(ICustomer customer)
        {
            _customer = customer;
        }

        public async Task<string> RegisterCustomer(Customer customer)
        {
            if(customer == null) throw new ArgumentNullException(nameof(customer));
            return await _customer.RegisterCustomer(customer);
        }
    }
}
