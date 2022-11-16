using AutoMapper;
using BookLibrary_API.Interfaces;
using BookLibrary_API.Models;

namespace BookLibrary_API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookRepository(DataContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<BookDTO> GetBooks()
        {
            return _context.Books.Select(x => _mapper.Map<BookDTO>(x)).ToList();
        }

        public Book? GetBookById(int id)
        {
            return _context.Books.Where(x => x.Id == id).FirstOrDefault() ?? null;
        }

        public List<BookDTO> AddBook(Book book)
        {
            _context.Books.Add(_mapper.Map<Book>(book));
            _context.SaveChanges();

            return _context.Books.Select(x => _mapper.Map<BookDTO>(x)).ToList();
        }

        public Book? DeleteBook(int id)
        {
            var book = _context.Books.Where(x => x.Id == id).FirstOrDefault();

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }

            return book;
        }

        public Book? UpdateBook(Book book)
        {
            var myBook = _context.Books.Where(x => x.Id == book.Id).FirstOrDefault();

            if (myBook != null)
            {
                myBook.Author = book.Author;
                myBook.ReleaseDate = book.ReleaseDate;
                myBook.Title = book.Title;

                _context.SaveChanges();
            }

            return myBook;
        }
    }
}
