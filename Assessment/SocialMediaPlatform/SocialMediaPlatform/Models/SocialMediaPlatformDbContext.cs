using Microsoft.EntityFrameworkCore;

namespace SocialMediaPlatform.Models
{
    public class SocialMediaPlatformDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public SocialMediaPlatformDbContext(DbContextOptions<SocialMediaPlatformDbContext> options) : base(options) { }
    }
}
