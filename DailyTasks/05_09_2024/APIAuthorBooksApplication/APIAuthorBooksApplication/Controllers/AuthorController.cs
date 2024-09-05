using APIAuthorBooksApplication.Interface;
using APIAuthorBooksApplication.Models;
using APIAuthorBooksApplication.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIAuthorBooksApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AuthorService _service;
        public AuthorController(AuthorService service)
        {
            _service = service;
        }


        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            return await _service.GetAllAuthors();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            return await _service.GetAuthorById(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Author author)
        {
            await _service.AddAuthor(author);
            return CreatedAtAction("Get", new { id = author.AuthorId }, author);
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Author author)
        {
            await _service.UpdateAuthor(id, author);
            return CreatedAtAction("Get", new { id = author.AuthorId }, author);
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAuthor(id);
            return Ok("Deleted.");
        }
    }
}
