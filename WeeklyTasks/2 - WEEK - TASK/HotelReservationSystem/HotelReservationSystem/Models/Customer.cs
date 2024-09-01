using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? phoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string? email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public string? ZipCode { get; set; }

        [Required]
        public string? State { get; set; }

        [Required]
        public string? Country { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}
