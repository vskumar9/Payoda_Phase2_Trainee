using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMediaPlatform.Models
{
    public class Post
    {
        [Key]
        
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedDate { get; set; }


        public int UserId { get; set; }

        [ForeignKey("UserId")]

        public User? User { get; set; }

    }
}
