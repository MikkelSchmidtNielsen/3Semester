using BlazorAppRESTAPIAssignments.Shared.Models;

namespace BlazorAppRESTAPIAssignments.Client.Services
{
    public interface IBookService
    {
        Task<Book[]?> GetAllBooks();
        Task<Book?> GetBook(string isbn);
        Task<int> AddBook(Book book);
        Task<int> DeleteBook(string isbn);
        Task<int> UpdateBook(Book book);
    }
}
