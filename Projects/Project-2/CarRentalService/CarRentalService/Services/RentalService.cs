using CarRentalService.Interface;
using CarRentalService.Models;
using CarRentalService.Repository;

namespace CarRentalService.Services
{
    public class RentalService
    {
        private readonly IRental _rental;

        public RentalService(IRental rental)
        {
            _rental = rental;
        }

        public async Task<string> RegisterRental(Rental model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            return await _rental.RegisterRental(model);
        }

        public async Task<IEnumerable<Rental>> GetAllRentals()
        {
            return await _rental.GetAllRentals();
        }

        public async Task<Rental> GetRental(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));
            return await _rental.GetRental(id);
        }

        public async Task<Rental> UpdateRental(Rental model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            return await _rental.UpdateRental(model);
        }

        public async Task<string> DeleteRental(Rental model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            return await _rental.DeleteRental(model);
        }

        public async Task<IEnumerable<Rental>> GetRentalHistory(string customerId)
        {
            if (customerId == null) throw new ArgumentNullException(nameof(customerId));
            return await _rental.GetRentalHistory(customerId);
        }

        public async Task<string> GetRentalReturnExpired(string vehicleId)
        {
            var existingRental = await _rental.GetRental(vehicleId);

            if (existingRental != null)
            {
                if (existingRental.ReturnDate.HasValue && existingRental.ReturnDate.Value < DateTime.UtcNow)
                {
                    return "ok";
                }
                else
                {
                    return null;
                }
            }
            return "ok";
        }

        public async Task<IEnumerable<Rental>> GetRentalsByDateRangeAsync(DateTime? startDate, DateTime? endDate)
        {
            return await _rental.GetRentalsByDateRangeAsync(startDate, endDate);
        }

        public async Task<IEnumerable<Rental>> GetRentalsAny(string? firstName = null, string? lastName = null, string? vehicleName = null, string? customerId = null, string? email = null, string? phoneNumber = null, string? vehicleId = null)
        {
            var rental = await _rental.GetRentalsAny(firstName, lastName, vehicleName, customerId, email, phoneNumber, vehicleId);
            if(rental != null) return rental;
            return null!;
        }

    }
}
