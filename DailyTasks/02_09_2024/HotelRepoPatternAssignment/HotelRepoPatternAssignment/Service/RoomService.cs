using HotelRepoPatternAssignment.Models;
using HotelRepoPatternAssignment.Repository;
using Microsoft.EntityFrameworkCore;

namespace HotelRepoPatternAssignment.Service
{
    public class RoomService : IRoom
    {
        private readonly HotelDBContext _dbContext;

        public RoomService(HotelDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddRoom(Room room)
        {
            _dbContext.Room.Add(room);
            _dbContext.SaveChanges();
        }

        public void DeleteRoom(Room room)
        {
            _dbContext.Room.Remove(room);
            _dbContext.SaveChanges();
        }

        public Models.Room? GetRoomById(int id)
        {
            return _dbContext.Room.Include( h => h.Hotel).FirstOrDefault(r => r.RoomId == id);
        }

        public IEnumerable<Room> GetRooms()
        {
            return _dbContext.Room.Include(h => h.Hotel);
        }

        public void UpdateRoom(Room room)
        {
            _dbContext.Room.Update(room);
            _dbContext.SaveChanges();
        }
    }
}
