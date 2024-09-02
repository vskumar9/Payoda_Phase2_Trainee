using HotelRepoPatternAssignment.Models;
using HotelRepoPatternAssignment.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelRepoPatternAssignment.Service
{
    public class HotelService : IHotel
    {
        private readonly HotelDBContext _dbContext;

        public HotelService(HotelDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddHotel(Hotel hotel)
        {
            _dbContext.Hotel.Add(hotel);
            _dbContext.SaveChanges();
        }

        public void DeleteHotel(Hotel hotel)
        {
            _dbContext.Hotel.Remove(hotel);
            _dbContext.SaveChanges();
        }

        public Models.Hotel? GetHotelById(int id)
        {
            return _dbContext.Hotel.Include(r => r.Room).FirstOrDefault(h => h.HotelId == id);
        }

        public IEnumerable<Models.Hotel> GetHotels()
        {
            return _dbContext.Hotel.ToList();
        }

        public void UpdateHotel(Hotel hotel)
        {
            _dbContext.Hotel.Update(hotel);
            _dbContext.SaveChanges();
        }
    }
}
