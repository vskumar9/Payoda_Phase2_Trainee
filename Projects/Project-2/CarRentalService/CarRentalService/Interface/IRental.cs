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
    }
}
