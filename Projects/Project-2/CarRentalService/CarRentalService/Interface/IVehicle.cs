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
        Task<IEnumerable<Vehicle>> GetVehiclesAny(string? vehicleId = null,
                                                  string? make = null,
                                                  string? model = null,
                                                  int? year = null,
                                                  string? color = null);
    }
}
