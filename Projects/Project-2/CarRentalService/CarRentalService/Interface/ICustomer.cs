using CarRentalService.Models;

namespace CarRentalService.Interface
{
    public interface ICustomer
    {
        Task<string> RegisterCustomer(Customer model);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomer(string id);
        Task<Customer> UpdateCustomer(Customer model);
        Task<string> DeleteCustomer(Customer model);
        Task<IEnumerable<Customer>> GetCustomersAny(string? customerId = null,
                                                    string? firstName = null,
                                                    string? lastName = null,
                                                    string? email = null,
                                                    string? phoneNumber = null);
        Task<int> GetTotalCustomers();
    }
}
