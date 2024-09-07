using CarRentalService.Interface;
using CarRentalService.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalService.Repository
{
    public class VehicleRepository : IVehicle
    {
        private readonly CarRentalDbContext _context;

        public VehicleRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public async Task<string> RegisterVehicle(Vehicle model)
        {
            var vehicle = new Vehicle
            {
                VehicleId = Guid.NewGuid().ToString(),
                Make = model.Make,
                Model = model.Model,
                Year = model.Year,
                Color = model.Color,
                RentalCount = model.RentalCount
            };

            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();

            return "Added";
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }

        public async Task<Vehicle> GetVehicle(string id)
        {
            return await _context.Vehicles.FindAsync(id) ?? throw new NullReferenceException();
        }

        public async Task<Vehicle> UpdateVehicle(Vehicle model)
        {
            var vehicle = await _context.Vehicles.FindAsync(model.VehicleId);
            if (vehicle == null)
            {
                return null;
            }

            //_context.Entry(model).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            vehicle.Make = model.Make;
            vehicle.Model = model.Model;
            vehicle.Year = model.Year;
            vehicle.Color = model.Color;
            vehicle.RentalCount = model.RentalCount;

            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();

            return vehicle;
        }

        public async Task<string> DeleteVehicle(Vehicle model)
        {
            var vehicle = await _context.Vehicles.FindAsync(model.VehicleId);
            if (vehicle == null)
            {
                return "NotFound";
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return "Deleted";
        }
    }
}
