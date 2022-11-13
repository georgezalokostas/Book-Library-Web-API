using BookLibrary_API.Interfaces;
using BookLibrary_API.Models;

namespace BookLibrary_API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.OrderBy(x => x.Id).ToList();
        }
    }
}
