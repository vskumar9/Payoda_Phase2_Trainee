using APIAuthorBooksApplication.Models;

namespace APIAuthorBooksApplication.Interface
{
    public interface IAuthor
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
        Task AddAuthor(Author author);
        Task UpdateAuthor(int id, Author author);
        Task DeleteAuthor(int id);
    }
}
