using BlazorAppRESTAPIAssignments.Components.Models;
using BlazorAppRESTAPIAssignments.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlazorAppRESTAPIAssignments.Controllers
{
    [ApiController]
    [Route("api/bookapi")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository Repository = new BookRepository();

        public BookController(IBookRepository bookRepository)
        {
            if (Repository == null && bookRepository != null)
            {
                Repository = bookRepository;
                Console.WriteLine("Repository initialized");
            }
        }

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return Repository.GetAllBooks();
        }

        [HttpDelete("{isbn}")]
        public StatusCodeResult DeleteBook(string isbn)
        {
            Console.WriteLine("Server: Delete item called: isbn = " + isbn);

            bool deleted = Repository.DeleteBook(isbn);
            if (deleted)
            {
                Console.WriteLine("Server: Item deleted succces");
                int code = (int)HttpStatusCode.OK;
                return new StatusCodeResult(code);
            }
            else
            {
                Console.WriteLine("Server: Item deleted fail - not found");
                int code = (int)HttpStatusCode.NotFound;
                return new StatusCodeResult(code);
            }
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            Console.WriteLine("Add item called: " + book.ToString());

            if (book == null)
                return BadRequest(); // ErrorCode 400 - hvis objektet mangler

            Repository.AddBook(book);

            Console.WriteLine("AddBook is called?");

            return Ok(); // return Ok = errorcode 200
        }

        [HttpGet("{isbn}")]
        public Book FindBook(string isbn)
        {
            var result = Repository.FindBook(isbn);
            return result;
        }

        [HttpPut]
        public bool UpdateBook(Book book)
        {
            var result = Repository.UpdateBook(book);
            return result;
        }
    }
}
