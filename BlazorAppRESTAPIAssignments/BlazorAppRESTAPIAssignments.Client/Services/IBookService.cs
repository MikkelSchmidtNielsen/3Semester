using BlazorAppRESTAPIAssignments.Shared.Models;

namespace BlazorAppRESTAPIAssignments.Client.Services
{
    public interface IBookService
    {
        Task<Book[]?> GetAllBooks();
        Task<Book?> GetBook(int id);
        Task<int> AddBook(Book book);
        Task<int> DeleteBook(int id);
        Task<int> UpdateBook(Book book);
    }
}
