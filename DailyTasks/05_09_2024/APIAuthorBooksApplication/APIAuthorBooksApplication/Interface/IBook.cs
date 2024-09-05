using APIAuthorBooksApplication.Models;

namespace APIAuthorBooksApplication.Interface
{
    public interface IBook
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetABookById(int id);
        Task AddBook(Book book);
        Task UpdateBook(int id, Book book);
        Task DeleteBook(int id);
    }
}
