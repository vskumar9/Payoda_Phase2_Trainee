using HotelRepoPatternAssignment.Models;

namespace HotelRepoPatternAssignment.Repository
{
    public interface IHotel
    {
        IEnumerable<Hotel> GetHotels();

        Hotel? GetHotelById(int id);

        void AddHotel(Hotel hotel);

        void UpdateHotel(Hotel hotel);

        void DeleteHotel(Hotel hotel);
    }
}
