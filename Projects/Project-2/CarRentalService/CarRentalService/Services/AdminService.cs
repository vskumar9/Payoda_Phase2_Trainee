using CarRentalService.Interface;
using CarRentalService.Models;
using CarRentalService.Repository;
using Microsoft.VisualBasic;

namespace CarRentalService.Services
{
    public class AdminService
    {
        private readonly IAdmin _admin;
        public AdminService(IAdmin admin)
        {
            _admin = admin;
        }

        public async Task<string> RegisterAdmin(Admin admin)
        {
            try
            {
                if (admin == null) return "Invalid admin";
                return await _admin.RegisterAdmin(admin);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            try
            {
                return await _admin.GetAllAdmins();
            }
            catch
            {
                throw;
            }
        }
        public async Task<Admin> GetAdmin(string id)
        {
            try
            {
                return await _admin.GetAdmin(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Admin> UpdateAdmin(Admin model)
        {
            try
            {
                return await _admin.UpdateAdmin(model);
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> DeleteAdmin(Admin model)
        {
            try
            {
                return await _admin.DeleteAdmin(model);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Admin>> GetAdminsAny(string? adminId = null, string? username = null, string? email = null, string? fullName = null)
        {
            try
            {
                var admin = await _admin.GetAdminsAny(adminId, username, email, fullName);
                if(admin == null) return null!;
                return admin;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> GetTotalAdmins()
        {
            try
            {
                return await _admin.GetTotalAdmins();
            }
            catch
            {
                throw;
            }
        }




    }
}
