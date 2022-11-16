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
    public IActionResult GetBooks()
    {
        var books = _bookrepository.GetBooks();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(books);
    }

    [HttpGet]
    [Route("api/{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = _bookrepository.GetBookById(id);

        if (book == null)
            return BadRequest("Book Not Found");

        return Ok(book);
    }

    [HttpPost]
    public IActionResult AddBook(Book book)
    {
        _bookrepository.AddBook(new Book
        {
            Author = book.Author,
            Title = book.Title,
            ReleaseDate = book.ReleaseDate,
            IsAvailable = true
        });

        return Ok(_bookrepository.GetBooks());
    }

    [HttpDelete]
    [Route("api/delete/{id}")]
    public IActionResult DeleteBook(int id)
    {
       var book = _bookrepository.DeleteBook(id);

        if (book is null)
            return BadRequest("Book Not Found");

        return Ok(book);
    }

    [HttpPut]
    public IActionResult UpdateBook(Book book)
    {
        var result = _bookrepository.UpdateBook(book);

        if (result is null)
            return BadRequest("Could not update book");

        return Ok(result);
    }
}
