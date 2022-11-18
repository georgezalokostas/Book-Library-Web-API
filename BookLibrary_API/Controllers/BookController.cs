using BookLibrary_API.Interfaces;
using BookLibrary_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary_API.Controllers;

[Route("api/GetBooks")]
[ApiController]
public class BookController : Controller
{
    private readonly IBookRepository _bookrepository;

    public BookController(IBookRepository bookrepository)
    {
        _bookrepository = bookrepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _bookrepository.GetBooks();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(books);
    }

    [HttpGet]
    [Route("api/{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _bookrepository.GetBookById(id);

        if (book == null)
            return BadRequest("Book Not Found");

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(Book book)
    {
        await _bookrepository.AddBook(new Book
        {
            Author = book.Author,
            Title = book.Title,
            ReleaseDate = book.ReleaseDate,
            IsAvailable = true
        });

        return Ok(await _bookrepository.GetBooks());
    }

    [HttpDelete]
    [Route("api/delete/{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _bookrepository.DeleteBook(id);

        if (book is null)
            return BadRequest("Book Not Found");

        return Ok(book);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook(Book book)
    {
        var result = await _bookrepository.UpdateBook(book);

        if (result is null)
            return BadRequest("Could not update book");

        return Ok(result);
    }
}
