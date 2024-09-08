using CarRentalService.Models;

namespace CarRentalService.Interface
{
    public interface IAdmin
    {
        Task<string> RegisterAdmin(Admin model);
        Task<IEnumerable<Admin>> GetAllAdmins();
        Task<Admin> GetAdmin(string id);
        Task<Admin> UpdateAdmin(Admin model);
        Task<string> DeleteAdmin(Admin model);
        Task<IEnumerable<Admin>> GetAdminsAny(string? adminId = null,
                                              string? username = null,
                                              string? email = null,
                                              string? fullName = null,
                                              string? sortBy = "Username",
                                              bool sortDescending = false);
        Task<int> GetTotalAdmins();
    }
}
