using HotelRepoPatternAssignment.Models;

namespace HotelRepoPatternAssignment.Repository
{
    public interface IRoom
    {
        IEnumerable<Room> GetRooms();

        Room? GetRoomById(int id);

        void AddRoom(Room room);

        void UpdateRoom(Room room);

        void DeleteRoom(Room room);
    }
}
