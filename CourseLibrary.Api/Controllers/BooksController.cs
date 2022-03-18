using CourseLibrary.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {


        private readonly BooksDB _myBooksDB;
        public BooksController(BooksDB myBooksDB)
        {
            _myBooksDB = myBooksDB;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var books = await _myBooksDB.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet]
        [Route("get-book-by-id")]
        public async Task<IActionResult> GetBooksByIdAsync(int id)
        {
            var book = await _myBooksDB.Books.FindAsync(id);
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Books books)
        {
            _myBooksDB.Books.Add(books);
            await _myBooksDB.SaveChangesAsync();
            return Created($"/get-book-by-id?id={books.BookID}", books);

        }
        [HttpPut]
        public async Task<IActionResult> PutAync(Books bookToUpdate)
        {
            _myBooksDB.Books.Update(bookToUpdate);
            await _myBooksDB.SaveChangesAsync();
            return NoContent();
        }
    }
}
