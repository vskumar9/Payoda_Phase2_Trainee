using Microsoft.EntityFrameworkCore;

namespace HotelRepoPatternAssignment.Models
{
    public class HotelDBContext : DbContext
    {
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Room> Room { get; set; }
        public HotelDBContext(DbContextOptions<HotelDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=PTSQLTESTDB01;database=MVC_KUMAR;integrated security=true;trustservercertificate = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasData(new Hotel() { HotelId = 1, HotelName = "Thaj Mahal" });
            modelBuilder.Entity<Hotel>()
                .HasData(new Hotel() { HotelId = 2, HotelName = "Munthaj Mahal" });
            modelBuilder.Entity<Hotel>()
                .HasData(new Hotel() { HotelId = 3, HotelName = "Andhra Mahal" });

           
            modelBuilder.Entity<Room>()
                .HasData(new Room() { RoomId = 11, RoomNumber = 101, RooomType = "Luxury", Price = 12000, HotelId = 1 });
            modelBuilder.Entity<Room>()
                .HasData(new Room() { RoomId = 12, RoomNumber = 101, RooomType = "Luxury", Price = 12000, HotelId = 2 });
            modelBuilder.Entity<Room>()
                .HasData(new Room() { RoomId = 13, RoomNumber = 101, RooomType = "Luxury", Price = 12000, HotelId = 3 });
            modelBuilder.Entity<Room>()
                .HasData(new Room() { RoomId = 14, RoomNumber = 101, RooomType = "Luxury", Price = 12000, HotelId = 1 });
            modelBuilder.Entity<Room>()
                .HasData(new Room() { RoomId = 15, RoomNumber = 101, RooomType = "Luxury", Price = 12000, HotelId = 2 });
            modelBuilder.Entity<Room>()
                .HasData(new Room() { RoomId = 16, RoomNumber = 101, RooomType = "Luxury", Price = 12000, HotelId = 3 });

            modelBuilder.Entity<Hotel>()
                .HasMany( r => r.Room)
                .WithOne( h => h.Hotel)
                .HasForeignKey( h => h.HotelId );


        
        }
    }
}
