using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalService.Models
{
    public class Customer
    {
        [Key]
        [Required]
        [StringLength(50)]
        public required string CustomerId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First name minimum characters 2 & maximum 100")]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Last name minimum characters 2 & maximum 100")]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255, MinimumLength = 10, ErrorMessage = "Email length min. 10 characters.")]
        public required string Email { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "Phone number must 10 to 12 digits.")]
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public required string PasswordHash { get; set; }
    }

}