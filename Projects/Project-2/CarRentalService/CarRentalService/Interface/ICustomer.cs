using CarRentalService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalService.Interface
{
    public interface ICustomer
    {
        Task<string> RegisterCustomer(Customer model);
    }
}
