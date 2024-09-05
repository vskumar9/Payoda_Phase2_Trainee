using APIAuthorBooksApplication.Interface;
using APIAuthorBooksApplication.Models;

namespace APIAuthorBooksApplication.Service
{
    public class AuthorService
    {
        private readonly IAuthor _author;
        public AuthorService(IAuthor author)
        {
            _author = author;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _author.GetAllAuthors();
        }
        public async Task<Author> GetAuthorById(int id)
        {
            return await _author.GetAuthorById(id);
        }
        public async Task AddAuthor(Author author)
        {
            await _author.AddAuthor(author);
        }
        public async Task UpdateAuthor(int id, Author author)
        {
            await _author.UpdateAuthor(id, author);
        }
        public async Task DeleteAuthor(int id)
        {
            await _author.DeleteAuthor(id);
        }
    }
}
