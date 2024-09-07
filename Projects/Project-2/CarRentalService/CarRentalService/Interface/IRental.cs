using CarRentalService.Models;

namespace CarRentalService.Interface
{
    public interface IRental
    {
        Task<string> RegisterRental(Rental model);
        Task<IEnumerable<Rental>> GetAllRentals();
        Task<Rental> GetRental(string id);
        Task<Rental> UpdateRental(Rental model);
        Task<string> DeleteRental(Rental model);
        Task<IEnumerable<Rental>> GetRentalHistory(string customerId);
        Task<IEnumerable<Rental>> GetRentalsByDateRangeAsync(DateTime? startDate, DateTime? endDate);
        Task<IEnumerable<Rental>> GetRentalsAny(string? firstName = null, 
                                                string? lastName = null, 
                                                string? vehicleName = null,
                                                string? customerId = null,
                                                string? email = null, 
                                                string? phoneNumber = null, 
                                                string? vehicleId = null);
    }
}
