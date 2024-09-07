using System.ComponentModel.DataAnnotations;

namespace CarRentalService.Models
{
    public class Vehicle
    {
        [Key]
        [StringLength(50)]
        public string? VehicleId { get; set; }

        [Required]
        [StringLength(100)]
        public string? Make { get; set; }

        [Required]
        [StringLength(100)]
        public string? Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [StringLength(50)]
        public string? Color { get; set; }

        public int RentalCount { get; set; }
    }
}
