using APIAuthorBooksApplication.Interface;
using APIAuthorBooksApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAuthorBooksApplication.Repository
{
    public class BookRepository : IBook
    {
        private readonly BookAuthorDbContext _context;

        public BookRepository(BookAuthorDbContext context)
        {
            _context = context;
        }

        public async Task AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Book> GetABookById(int id)
        {
            return await _context.Books.Include(a => a.BookAuthorList!).ThenInclude(a => a.author).FirstOrDefaultAsync(b => b.BookId == id) ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Books.Include(a => a.BookAuthorList!).ThenInclude(a => a.author).ToListAsync();
        }

        public async Task UpdateBook(int id, Book book)
        {
            if(id == book.BookId)
            {
                _context.Entry(book).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
