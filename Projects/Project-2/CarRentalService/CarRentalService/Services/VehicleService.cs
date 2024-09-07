using CarRentalService.Interface;
using CarRentalService.Models;

namespace CarRentalService.Services
{
    public class VehicleService
    {
        private readonly IVehicle _vehicle;

        public VehicleService(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public async Task<string> RegisterVehicle(Vehicle model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            return await _vehicle.RegisterVehicle(model);
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return await _vehicle.GetAllVehicles();
        }

        public async Task<Vehicle> GetVehicle(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return await _vehicle.GetVehicle(id);
        }

        public async Task<Vehicle> UpdateVehicle(Vehicle model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            return await _vehicle.UpdateVehicle(model);
        }

        public async Task<string> DeleteVehicle(Vehicle model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            return await _vehicle.DeleteVehicle(model);
        }

        public async Task<Vehicle> GetVehicleById(string id)
        {
            var vehicle = await _vehicle.GetVehicle(id);
            if (vehicle == null) return null;
            return vehicle;
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAny(string? vehicleId = null, string? make = null, string? model = null, int? year = null, string? color = null)
        {
            var vehicle = await _vehicle.GetVehiclesAny(vehicleId, make, model, year, color);
            if (vehicle == null) return Enumerable.Empty<Vehicle>();
            return vehicle;
        }


    }
}
