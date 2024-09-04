using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAuthorBooksApplication.Models;

namespace APIAuthorBooksApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorsController : ControllerBase
    {
        private readonly BookAuthorDbContext _context;

        public BookAuthorsController(BookAuthorDbContext context)
        {
            _context = context;
        }

        // GET: api/BookAuthors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookAuthor>>> GetBooksAuthor()
        {
            return await _context.BooksAuthor.Include(a => a.author).Include(b => b.book).ToListAsync();
        }

        // GET: api/BookAuthors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookAuthor>> GetBookAuthor(int id)
        {
            var bookAuthor = await _context.BooksAuthor.FirstOrDefaultAsync(b=>b.BookId==id);

            if (bookAuthor == null)
            {
                return NotFound();
            }

            return bookAuthor;
        }

        // PUT: api/BookAuthors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookAuthor(int id, BookAuthor bookAuthor)
        {
            if (id != bookAuthor.AuthorId)
            {
                return BadRequest();
            }

            _context.Entry(bookAuthor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookAuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookAuthors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookAuthor>> PostBookAuthor(BookAuthor bookAuthor)
        {
            _context.BooksAuthor.Add(bookAuthor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookAuthorExists(bookAuthor.AuthorId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookAuthor", new { id = bookAuthor.AuthorId }, bookAuthor);
        }

        // DELETE: api/BookAuthors/5
        [HttpDelete("{bookId}/{authorId}")]
        public async Task<IActionResult> DeleteBookAuthor(int bookId, int authorId)
        {
            var bookAuthor = await _context.BooksAuthor.FirstOrDefaultAsync(ba => ba.BookId == bookId && ba.AuthorId == authorId);
            if (bookAuthor == null)
            {
                return NotFound();
            }

            _context.BooksAuthor.Remove(bookAuthor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookAuthorExists(int id)
        {
            return _context.BooksAuthor.Any(e => e.AuthorId == id);
        }
    }
}
