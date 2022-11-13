using BookLibrary_API.Models;

namespace BookLibrary_API.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
    }
}
