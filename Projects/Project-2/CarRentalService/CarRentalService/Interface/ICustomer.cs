using CarRentalService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalService.Interface
{
    public interface ICustomer
    {
        Task<string> RegisterCustomer(Customer model);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomer(string id);
        Task<Customer> UpdateCustomer(Customer model);
        Task<string> DeleteCustomer(Customer model);
    }
}
