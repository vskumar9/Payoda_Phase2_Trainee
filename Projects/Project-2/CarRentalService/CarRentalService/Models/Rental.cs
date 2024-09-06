using CarRentalService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CarRentalService.Models
{
    public class Rental
    {
        [Key]
        [Required]
        [StringLength(50)]
        public required string RentalId { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public required string CustomerId { get; set; }

        [Required]
        [ForeignKey("Vehicle")]
        public required string VehicleId { get; set; }

        [Required]
        public DateTime RentalDate { get; set; }

        [Required]
        public DateTime? ReturnDate { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public Customer? Customer { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}