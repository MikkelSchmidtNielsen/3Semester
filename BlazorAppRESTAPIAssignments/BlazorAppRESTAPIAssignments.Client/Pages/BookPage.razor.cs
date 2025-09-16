using BlazorAppRESTAPIAssignments.Shared.Models;
using System.Net;

namespace BlazorAppRESTAPIAssignments.Client.Pages
{
    public partial class BookPage
    {
        private List<Book> Books { get; set; } = new List<Book>();
        private Book BookModel { get; set; } = new Book();
        private int ErrorCode { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            Books = (await _bookService.GetAllBooks()).ToList();
        }

        private async Task AddBookHandler()
        {
            ErrorCode = await _bookService.AddBook(BookModel);

            Console.WriteLine("Book added: return code: " + ErrorCode);

            if (ErrorCode == (int)HttpStatusCode.OK)
            {
                BookModel = new Book();

                Books = (await _bookService.GetAllBooks()).ToList();
            }
        }
    }
}
