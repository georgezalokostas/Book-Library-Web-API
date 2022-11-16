using BookLibrary_API.Models;

namespace BookLibrary_API.Interfaces
{
    public interface IBookRepository
    {
        List<BookDTO> GetBooks();
        Book? GetBookById(int id);
        List<BookDTO> AddBook(Book book);
        Book? DeleteBook(int id);
    }
}
