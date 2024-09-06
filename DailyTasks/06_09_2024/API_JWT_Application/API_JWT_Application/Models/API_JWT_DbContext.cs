using Microsoft.EntityFrameworkCore;

namespace API_JWT_Application.Models
{
    public class API_JWT_DbContext : DbContext 
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Users> Users { get; set; }
        public API_JWT_DbContext(DbContextOptions<API_JWT_DbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasData(new Book() { BookId = 1, Title = "My Life", AuthorName = "Sanjeev", Price = 200});
            modelBuilder.Entity<Book>()
                .HasData(new Book() { BookId = 2, Title = "Beauty beast", AuthorName = "Sanjay", Price = 300 });
            modelBuilder.Entity<Book>()
                .HasData(new Book() { BookId = 3, Title = "See It Once", AuthorName = "San ray", Price = 500 });

        }
    }
}
