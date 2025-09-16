using BlazorAppRESTAPIAssignments.Shared.Models;

namespace BlazorAppRESTAPIAssignments.Components.Models
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book FindBook(string Isbn);
        void AddBook(Book book);
        bool DeleteBook(string Isbn);
        bool UpdateBook(Book book);
    }
}
