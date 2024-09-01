namespace HotelReservationSystem.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        public string RoomNumber { get; set; } = null!;

        public string RoomType { get; set; } = null!;

        public decimal Price { get; set; }

        public bool IsAvailable { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
