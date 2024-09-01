using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Models
{
    public class HotelDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        
        public DbSet<Reservation> Reservations { get; set; }

        public HotelDBContext(DbContextOptions options) : base(options) { }
    }
}
