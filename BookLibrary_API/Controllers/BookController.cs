using BookLibrary_API.Interfaces;
using BookLibrary_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace BookLibrary_API.Controllers
{
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        public IActionResult GetBooks()
        {
            var books = _bookrepository.GetBooks();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(books);
        }
    }
}
