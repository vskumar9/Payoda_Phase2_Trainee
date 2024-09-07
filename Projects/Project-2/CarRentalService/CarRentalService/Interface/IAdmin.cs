﻿using CarRentalService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalService.Interface
{
    public interface IAdmin
    {
        Task<string> RegisterAdmin(Admin model);
        Task<IEnumerable<Admin>> GetAllAdmins();
        Task<Admin> GetAdmin(string id);
        Task<Admin> UpdateAdmin(Admin model);
        Task<string> DeleteAdmin(Admin model);
    }
}
