using System.ComponentModel.DataAnnotations;

namespace API_JWT_Application.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? Password { get; set; }
    }
}
