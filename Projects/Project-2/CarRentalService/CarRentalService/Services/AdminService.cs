using CarRentalService.Interface;
using CarRentalService.Models;
using CarRentalService.Repository;

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
            if (admin == null) throw new ArgumentNullException(nameof(admin));
            return await _admin.RegisterAdmin(admin);
        }
        public async Task<IEnumerable<Admin>> GetAllAdmins()
        {
            return await _admin.GetAllAdmins();
        }
        public async Task<Admin> GetAdmin(string id)
        {
            if (id == null) throw new ArgumentNullException();
            return await _admin.GetAdmin(id);
        }

        public async Task<Admin> UpdateAdmin(Admin model)
        {
            if (model == null) throw new ArgumentNullException();
            return await _admin.UpdateAdmin(model);
        }

        public async Task<string> DeleteAdmin(Admin model)
        {
            if (model == null) throw new ArgumentNullException();
            return await _admin.DeleteAdmin(model);
        }

        public async Task<IEnumerable<Admin>> GetAdminsAny(string? adminId = null, string? username = null, string? email = null, string? fullName = null)
        {
            var admin = await _admin.GetAdminsAny(adminId, username, email, fullName);
            if(admin == null) return null!;
            return admin;
        }



    }
}
