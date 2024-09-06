using CarRentalService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalService.Interface
{
    public interface IAdmin
    {
        Task<string> RegisterAdmin(Admin model);
    }
}
