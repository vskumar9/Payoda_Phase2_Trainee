using APIAuthorBooksApplication.Interface;
using APIAuthorBooksApplication.Models;
using SQLitePCL;

namespace APIAuthorBooksApplication.Service
{
    public class BookService
    {
        private readonly IBook _book;
        public BookService(IBook book)
        {
            _book = book;
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _book.GetAllBooks();
        }
        public async Task<Book> GetABookById(int id)
        {
            return await _book.GetABookById(id);
        }
        public async Task AddBook(Book book)
        {
            await _book.AddBook(book);
        }
        public async Task UpdateBook(int id, Book book)
        {
            await _book.UpdateBook(id, book);
        }
        public async Task DeleteBook(int id)
        {
            await _book.DeleteBook(id);
        }
    }
}
