using APIAuthorBooksApplication.Interface;
using APIAuthorBooksApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace APIAuthorBooksApplication.Repository
{
    public class AuthorRepository : IAuthor
    {
        private readonly BookAuthorDbContext _context;

        public AuthorRepository(BookAuthorDbContext context)
        {
            _context = context;
        }

        public async Task AddAuthor(Author author)
        {
            await _context.Author.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthor(int id)
        {
            var author = await _context.Author.FindAsync(id);
            if(author != null)
            {
                _context.Author.Remove(author);
                await _context.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _context.Author.Include(b => b.BookAuthorList!).ThenInclude(a => a.book).ToListAsync();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _context.Author.Include(b => b.BookAuthorList!).ThenInclude(a => a.book).FirstOrDefaultAsync(a => a.AuthorId == id) ?? throw new NullReferenceException();
        }

        public async Task UpdateAuthor(int id, Author author)
        {
            if (id == author.AuthorId)
            {
                _context.Entry(author).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

        }
    }
}
