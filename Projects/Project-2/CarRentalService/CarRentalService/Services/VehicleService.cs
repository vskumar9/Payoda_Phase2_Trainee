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
            try
            {
                return await _vehicle.RegisterVehicle(model);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            try
            {
                return await _vehicle.GetAllVehicles();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Vehicle> GetVehicle(string id)
        {
            try
            {
                return await _vehicle.GetVehicle(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Vehicle> UpdateVehicle(Vehicle model)
        {
            try
            {
                return await _vehicle.UpdateVehicle(model);
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> DeleteVehicle(Vehicle model)
        {
            try
            {
                return await _vehicle.DeleteVehicle(model);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Vehicle> GetVehicleById(string id)
        {
            try
            {
                var vehicle = await _vehicle.GetVehicle(id);
                if (vehicle == null) return null;
                return vehicle;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAny(string? vehicleId = null, string? make = null, string? model = null, int? year = null, string? color = null)
        {
            try
            {
                var vehicle = await _vehicle.GetVehiclesAny(vehicleId, make, model, year, color);
                if (vehicle == null) return Enumerable.Empty<Vehicle>();
                return vehicle;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> GetTotalVehicles()
        {
            try
            {
                return await _vehicle.GetTotalVehicles();
            }
            catch
            {
                throw;
            }
        }
    }
}
