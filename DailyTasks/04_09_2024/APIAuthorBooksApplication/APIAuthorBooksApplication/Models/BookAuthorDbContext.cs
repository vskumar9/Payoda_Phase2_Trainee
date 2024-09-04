using Microsoft.EntityFrameworkCore;

namespace APIAuthorBooksApplication.Models
{
    public class BookAuthorDbContext : DbContext
    {
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BooksAuthor { get; set; }

        public BookAuthorDbContext(DbContextOptions<BookAuthorDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.AuthorId, ba.BookId });

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.book)
                .WithMany(ba => ba.BookAuthorList)
                .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<BookAuthor>()
                .HasOne(ba => ba.author)
                .WithMany(ba => ba.BookAuthorList)
                .HasForeignKey(ba => ba.AuthorId);
        }
    }
}
