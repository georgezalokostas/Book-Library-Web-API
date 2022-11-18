using AutoMapper;
using BookLibrary_API.Interfaces;
using BookLibrary_API.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<BookDTO>> GetBooks()
        {
            return await _context.Books.Select(x => _mapper.Map<BookDTO>(x)).ToListAsync();
        }

        public async Task<Book?> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync() ?? null;
        }

        public async Task<List<BookDTO>> AddBook(Book book)
        {
            _context.Books.Add(_mapper.Map<Book>(book));
            await _context.SaveChangesAsync();

            return await _context.Books.Select(x => _mapper.Map<BookDTO>(x)).ToListAsync();
        }

        public async Task<Book?> DeleteBook(int id)
        {
            var book = await _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }

            return book;
        }

        public async Task<Book?> UpdateBook(Book book)
        {
            var myBook = await _context.Books.Where(x => x.Id == book.Id).FirstOrDefaultAsync();

            if (myBook != null)
            {
                myBook.Author = book.Author;
                myBook.ReleaseDate = book.ReleaseDate;
                myBook.Title = book.Title;

                await _context.SaveChangesAsync();
            }

            return myBook;
        }
    }
}
