using Microsoft.AspNetCore.Mvc;
using SmartLibrary.API.Entities;
using SmartLibrary.API.Persistence;

namespace SmartLibrary.API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksDbContext _booksDbContext;
        public BooksController(BooksDbContext context)
        {
            _booksDbContext = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _booksDbContext.Books.Where(b => b.IsRemoved == false).ToList();

            return Ok(books);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var book = _booksDbContext.Books.SingleOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpPost]
        public IActionResult Post(Book input)
        {
            var book = new Book(input.Title, input.Author, input.ISBN, input.PublicationYear);
            _booksDbContext.Books.Add(book);

            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Book input)
        {
            var book = _booksDbContext.Books.SingleOrDefault(b => b.Id == id);
            
            if (book == null) 
            { 
                return NotFound(); 
            }

            book.Title = input.Title;
            book.Author = input.Author;
            book.ISBN = input.ISBN;
            book.PublicationYear = input.PublicationYear;

            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            var book = _booksDbContext.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            book.RemoveBook();

            return NoContent();
        }
    }
}
