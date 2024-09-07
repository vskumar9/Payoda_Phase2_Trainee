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
    }
}
