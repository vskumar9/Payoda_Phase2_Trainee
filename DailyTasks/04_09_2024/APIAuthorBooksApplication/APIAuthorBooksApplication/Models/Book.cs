namespace APIAuthorBooksApplication.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public decimal? Price { get; set; }

        public ICollection<BookAuthor>? BookAuthorList { get; set; }
    }
}
