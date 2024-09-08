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
            try
            {
                var vehicle = new Vehicle
                {
                    VehicleId = model.VehicleId,
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
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehicles()
        {
            try
            {
                return await _context.Vehicles.ToListAsync();
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
                return await _context.Vehicles.FindAsync(id) ?? throw new NullReferenceException();
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
                var vehicle = await _context.Vehicles.FindAsync(model.VehicleId);
                if (vehicle == null)
                {
                    return null!;
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
            catch
            {
                throw;
            }
        }

        public async Task<string> DeleteVehicle(Vehicle model)
        {
            try
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
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAny(string? vehicleId = null, string? make = null, string? model = null, int? year = null, 
            string? color = null, string? sortBy = "Make", bool sortDescending = false)
        {
            try
            {

                var query = _context.Vehicles.AsQueryable();

                if (!string.IsNullOrEmpty(vehicleId))
                {
                    query = query.Where(v => v.VehicleId == vehicleId);
                }

                if (!string.IsNullOrEmpty(make))
                {
                    var lowerMake = make.ToLower();
                    query = query.Where(v => v.Make != null && v.Make.ToLower().Contains(lowerMake));
                }

                if (!string.IsNullOrEmpty(model))
                {
                    var lowerModel = model.ToLower();
                    query = query.Where(v => v.Model != null && v.Model.ToLower().Contains(lowerModel));
                }

                if (year.HasValue)
                {
                    query = query.Where(v => v.Year == year.Value);
                }

                if (!string.IsNullOrEmpty(color))
                {
                    var lowerColor = color.ToLower();
                    query = query.Where(v => v.Color != null && v.Color.ToLower().Contains(lowerColor));
                }

                query = sortDescending ? ApplySorting(query, sortBy!, true) : ApplySorting(query, sortBy!, false);

                return await query.ToListAsync();
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
                return await _context.Vehicles.CountAsync();
            }
            catch
            {
                throw;
            }
        }

        private IQueryable<Vehicle> ApplySorting(IQueryable<Vehicle> query, string sortBy, bool descending)
        {
            return sortBy.ToLower() switch
            {
                "vehicleid" => descending ? query.OrderByDescending(v => v.VehicleId) : query.OrderBy(v => v.VehicleId),
                "make" => descending ? query.OrderByDescending(v => v.Make) : query.OrderBy(v => v.Make),
                "model" => descending ? query.OrderByDescending(v => v.Model) : query.OrderBy(v => v.Model),
                "year" => descending ? query.OrderByDescending(v => v.Year) : query.OrderBy(v => v.Year),
                "color" => descending ? query.OrderByDescending(v => v.Color) : query.OrderBy(v => v.Color),
                "rentalcount" => descending ? query.OrderByDescending(v => v.RentalCount) : query.OrderBy(v => v.RentalCount),
                _ => descending ? query.OrderByDescending(v => v.Make) : query.OrderBy(v => v.Make),
            };
        }
    }
}
