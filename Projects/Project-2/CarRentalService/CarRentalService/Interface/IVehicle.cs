using CarRentalService.Models;

namespace CarRentalService.Interface
{
    public interface IVehicle
    {
        Task<string> RegisterVehicle(Vehicle model);
        Task<IEnumerable<Vehicle>> GetAllVehicles();
        Task<Vehicle> GetVehicle(string id);
        Task<Vehicle> UpdateVehicle(Vehicle model);
        Task<string> DeleteVehicle(Vehicle model);
    }
}
