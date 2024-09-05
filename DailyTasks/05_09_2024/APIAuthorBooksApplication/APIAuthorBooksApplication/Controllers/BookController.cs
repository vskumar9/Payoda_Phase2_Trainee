using APIAuthorBooksApplication.Interface;
using APIAuthorBooksApplication.Models;
using APIAuthorBooksApplication.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIAuthorBooksApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _service;
        public BookController(BookService service)
        {
            _service = service;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await _service.GetAllBooks();
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<Book> Get(int id)
        {
            return await _service.GetABookById(id);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            if (book != null)
            {
                await _service.AddBook(book);
                return CreatedAtAction("Get", new { id = book.BookId }, book);
            }
            return BadRequest();

        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book book)
        {
            await _service.UpdateBook(id, book);
            return CreatedAtAction("Get", new { id = book.BookId }, book);
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteBook(id);
            return Ok("Deleted.");
        }
    }
}
