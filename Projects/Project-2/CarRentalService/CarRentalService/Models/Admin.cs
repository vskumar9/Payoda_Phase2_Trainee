using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CarRentalService.Models
{
    public class Admin
    {
        [Key]
        [Required]
        [StringLength(50)]
        public required string AdminId { get; set; }

        [Required]
        [StringLength(50)]
        public required string Username { get; set; }

        [Required]
        [StringLength(255)]
        public required string PasswordHash { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [StringLength(100)]
        public required string FullName { get; set; }

        [Required]
        public DateTime? CreatedDate { get; set; }

        public DateTime? LastLoginDate { get; set; }
    }
}
