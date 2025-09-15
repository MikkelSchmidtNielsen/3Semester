using BlazorAppRESTAPIAssignments.Shared.Models;
using System.Net.Http.Json;

namespace BlazorAppRESTAPIAssignments.Client.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<int> AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book[]?> GetAllBooks()
        {
            var result = _httpClient.GetFromJsonAsync<Book[]>("sample-data/bookdata.json");

            return result;
        }

        public Task<Book?> GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
