using CarRentalService.Interface;
using CarRentalService.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Rental>> GetAllRentals()
        {
            return await _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Vehicle)
                .ToListAsync();
        }

        public async Task<Rental> GetRental(string id)
        {
            return await _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Vehicle)
                .FirstOrDefaultAsync(r => r.RentalId == id) ?? throw new NullReferenceException();
        }

        public async Task<Rental> UpdateRental(Rental model)
        {
            var rental = await _context.Rentals.FindAsync(model.RentalId);
            if (rental == null)
            {
                return null;
            }

            //_context.Entry(model).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            rental.CustomerId = model.CustomerId;
            rental.VehicleId = model.VehicleId;
            rental.RentalDate = model.RentalDate;
            rental.ReturnDate = model.ReturnDate;
            rental.Cost = model.Cost;

            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();

            return rental;
        }

        public async Task<string> DeleteRental(Rental model)
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

        public async Task<IEnumerable<Rental>> GetRentalHistory(string customerId)
        {
            return await _context.Rentals.Include(c =>  c.Customer).Include(v => v.Vehicle)
                .Where(r => r.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Rental>> GetRentalsByDateRangeAsync(DateTime? startDate, DateTime? endDate)
        {
            return await _context.Rentals.Include(c => c.Customer).Include(v => v.Vehicle)
            .Where(r => r.RentalDate >= startDate && r.RentalDate <= endDate)
            .ToListAsync();
        }

        public async Task<IEnumerable<Rental>> GetRentalsAny(string? firstName = null, string? lastName = null, string? vehicleName = null, string? customerId = null, string? email = null, string? phoneNumber = null, string? vehicleId = null)
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
    }
}
