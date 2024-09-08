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
            try
            {
                //var rental = await _rental.RegisterRental(model);
                //if (rental.Contains("Vehicle or Customer Not found.")) return rental;
                return await _rental.RegisterRental(model);
            }
            catch (Exception ex)
            {
                throw ex ?? new Exception();
            }
        }

        public async Task<IEnumerable<Rental>> GetAllRentals()
        {
            try
            {
                return await _rental.GetAllRentals();
            }
            catch (Exception ex)
            {
                throw ex ?? new Exception();
            }
        }

        public async Task<Rental> GetRental(string id)
        {
            try
            {
                return await _rental.GetRental(id);
            }
            catch (Exception ex)
            {
                throw ex ?? new Exception();
            }
        }

        public async Task<Rental> UpdateRental(Rental model)
        {
            try
            {
                return await _rental.UpdateRental(model);
            }
            catch (Exception ex)
            {
                throw ex ?? new Exception();
            }
        }

        public async Task<string> DeleteRental(Rental model)
        {
            try
            {
                return await _rental.DeleteRental(model);
            }
            catch (Exception ex)
            {
                throw ex ?? new Exception();
            }
        }

        public async Task<IEnumerable<Rental>> GetRentalHistory(string customerId)
        {
            try
            {
                return await _rental.GetRentalHistory(customerId);
            }
            catch (Exception ex)
            {
                throw ex ?? new Exception();
            }
        }

        public async Task<string> GetRentalReturnExpired(string vehicleId)
        {
            try
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
                        return null!;
                    }
                }
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex ?? new Exception();
            }
        }

        public async Task<IEnumerable<Rental>> GetRentalsByDateRangeAsync(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                return await _rental.GetRentalsByDateRangeAsync(startDate, endDate);
            }
            catch (Exception ex)
            {
                throw ex ?? new Exception();
            }
        }

        public async Task<IEnumerable<Rental>> GetRentalsAny(string? firstName = null, string? lastName = null, string? vehicleName = null, string? customerId = null, string? email = null, string? phoneNumber = null, string? vehicleId = null)
        {
            try
            {
                var rental = await _rental.GetRentalsAny(firstName, lastName, vehicleName, customerId, email, phoneNumber, vehicleId);
                if (rental != null) return rental;
                return null!;
            }
            catch (Exception ex)
            {
                throw ex ?? new Exception();
            }
        }

    }
}
