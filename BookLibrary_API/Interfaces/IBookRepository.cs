using BookLibrary_API.Models;

namespace BookLibrary_API.Interfaces;

public interface IBookRepository
{
    Task<List<BookDTO>> GetBooks();
    Task<Book?> GetBookById(int id);
    Task<List<BookDTO>> AddBook(Book book);
    Task<Book?> DeleteBook(int id);
    Task<Book?> UpdateBook(Book book);
}
