using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        public int? CustomerId { get; set; }

        public int? RoomId { get; set; }

        public DateTime? CheckInDate { get; set; }

        public DateTime? CheckOutDate { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room? Room { get; set; }
    }
}
