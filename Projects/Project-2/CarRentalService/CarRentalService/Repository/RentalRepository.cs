using CarRentalService.Interface;
using CarRentalService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarRentalService.Repository
{
    public class RentalRepository : IRental
    {
        private readonly CarRentalDbContext _context;

        public RentalRepository(CarRentalDbContext context)
        {
            _context = context;
        }

        public async Task<string> RegisterRental(Rental model)
        {
            try
            {
                var vehicle = await _context.Vehicles.FindAsync(model.VehicleId);
                var customer = await _context.Customers.FindAsync(model.CustomerId);

                if (vehicle == null || customer == null)
                {
                    return "Vehicle or Customer Not found.";
                }

                var latestRental = await _context.Rentals
                    .Where(r => r.VehicleId == model.VehicleId)
                    .OrderByDescending(r => r.RentalDate)
                    .FirstOrDefaultAsync();

                if (latestRental != null && latestRental.ReturnDate.HasValue && latestRental.ReturnDate.Value >= DateTime.UtcNow)
                {
                    
                    return "Vehicle Rentaled.";
                }

                if (model.RentalDate < DateTime.UtcNow || model.RentalDate >= model.ReturnDate)
                {
                    return "Rnetal date or return date wrong!";
                }

                var rental = new Rental
                {
                    RentalId = model.RentalId,
                    CustomerId = model.CustomerId,
                    VehicleId = model.VehicleId,
                    RentalDate = model.RentalDate,
                    ReturnDate = model.ReturnDate,
                    Cost = model.Cost
                };

                await _context.Rentals.AddAsync(rental);
                await _context.SaveChangesAsync();

                return "Added";
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<IEnumerable<Rental>> GetAllRentals()
        {
            try
            {
                return await _context.Rentals
                    .Include(r => r.Customer)
                    .Include(r => r.Vehicle)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Rental> GetRental(string id)
        {
            try
            {
                return await _context.Rentals
                    .Include(r => r.Customer)
                    .Include(r => r.Vehicle)
                    .FirstOrDefaultAsync(r => r.RentalId == id) ?? throw new NullReferenceException();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Rental> UpdateRental(Rental model)
        {
            try
            {
                // Fetch the existing rental record
                var rental = await _context.Rentals.FindAsync(model.RentalId);
                if (rental == null)
                {
                    return null!; // Rental not found
                }

                var vehicle = await _context.Vehicles.FindAsync(model.VehicleId);
                var customer = await _context.Customers.FindAsync(model.CustomerId);
                if (vehicle == null || customer == null)
                {
                    return null!; // Vehicle or customer not found
                }

                // Fetch the existing rental for the vehicle
                var latestRental = await _context.Rentals
                    .Where(r => r.VehicleId == model.VehicleId)
                    .OrderByDescending(r => r.RentalDate)
                    .FirstOrDefaultAsync();

                if (rental.VehicleId != model.VehicleId)
                {
                    if (latestRental != null && latestRental.ReturnDate.HasValue && latestRental.ReturnDate.Value >= DateTime.UtcNow)
                    {

                        return null!;
                    }
                }

                if(model.RentalDate != rental.RentalDate)
                {
                    if (model.RentalDate < DateTime.UtcNow)
                    {
                        return null!;
                    }
                }
                if (model.RentalDate >= model.ReturnDate)
                {
                    return null!;
                }


                // Update rental details
                rental.CustomerId = model.CustomerId;
                rental.VehicleId = model.VehicleId;
                rental.RentalDate = model.RentalDate;
                rental.ReturnDate = model.ReturnDate;
                rental.Cost = model.Cost;

                _context.Rentals.Update(rental);
                await _context.SaveChangesAsync();

                return rental;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<string> DeleteRental(Rental model)
        {
            try
            {
                var rental = await _context.Rentals.FindAsync(model.RentalId);
                if (rental == null)
                {
                    return "NotFound";
                }

                _context.Rentals.Remove(rental);
                await _context.SaveChangesAsync();

                return "Deleted";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Rental>> GetRentalHistory(string customerId)
        {
            try
            {
                return await _context.Rentals.Include(c => c.Customer).Include(v => v.Vehicle)
                    .Where(r => r.CustomerId == customerId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Rental>> GetRentalsByDateRangeAsync(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                return await _context.Rentals.Include(c => c.Customer).Include(v => v.Vehicle)
                .Where(r => r.RentalDate >= startDate && r.RentalDate <= endDate)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Rental>> GetRentalsAny(string? firstName = null, string? lastName = null, string? vehicleName = null, string? customerId = null, string? email = null, string? phoneNumber = null, string? vehicleId = null)
        {
            try
            {

                var query = _context.Rentals.Include(r => r.Customer).Include(r => r.Vehicle).AsQueryable();

                if (!string.IsNullOrEmpty(firstName) || !string.IsNullOrEmpty(lastName))
                {
                    var lowerFirstName = firstName?.ToLower();
                    var lowerLastName = lastName?.ToLower();
                    query = query.Where(r =>
                        (r.Customer!.FirstName != null && r.Customer.FirstName.ToLower().Contains(lowerFirstName ?? string.Empty)) &&
                        (r.Customer.LastName != null && r.Customer.LastName.ToLower().Contains(lowerLastName ?? string.Empty))
                    );
                }

                if (!string.IsNullOrEmpty(email))
                {
                    var lowerEmail = email?.ToLower();
                    query = query.Where(r =>
                        (r.Customer!.Email != null && r.Customer.Email.ToLower().Contains(lowerEmail ?? string.Empty))
                    );
                }

                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    var lowerPhoneNumber = phoneNumber?.ToLower();
                    query = query.Where(r =>
                        (r.Customer!.PhoneNumber != null && r.Customer.PhoneNumber.ToLower().Contains(lowerPhoneNumber ?? string.Empty))
                    );
                }

                if (!string.IsNullOrEmpty(vehicleId))
                {
                    var lowerVehicleId = vehicleId?.ToLower();
                    query = query.Where(r =>
                        (r.Vehicle!.VehicleId != null && r.Vehicle.VehicleId.ToLower().Contains(lowerVehicleId ?? string.Empty))
                    );
                }

                if (!string.IsNullOrEmpty(vehicleName))
                {
                    var lowerVehicleName = vehicleName?.ToLower();
                    query = query.Where(r =>
                        (r.Vehicle!.Make != null && r.Vehicle.Make.ToLower().Contains(lowerVehicleName ?? string.Empty)) ||
                        (r.Vehicle.Model != null && r.Vehicle.Model.ToLower().Contains(lowerVehicleName ?? string.Empty))
                    );
                }

                return await query.ToListAsync();
            }
            catch(Exception ex)
            {
                throw;
            }

        }
    }
}
