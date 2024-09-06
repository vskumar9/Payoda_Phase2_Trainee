using CarRentalService.Interface;
using CarRentalService.Models;

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
    }
}
