using CarRentalService.Interface;
using CarRentalService.Models;

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
    }
}
