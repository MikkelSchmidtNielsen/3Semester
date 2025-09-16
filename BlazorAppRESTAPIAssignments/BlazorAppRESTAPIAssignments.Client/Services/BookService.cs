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

        public Task<Book[]> GetAllBooks()
        {
            var result = _httpClient.GetFromJsonAsync<Book[]>("api/bookapi");

            return result;
        }

        public async Task<int> AddBook(Book book)
        {
            Console.WriteLine("Service is called!");
            var response = await _httpClient.PostAsJsonAsync("api/bookapi", book);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<Book?> GetBook(string isbn)
        {
            var result = await _httpClient.GetFromJsonAsync<Book>("api/bookapi/" + isbn);
            return result;
        }

        public async Task<int> DeleteBook(string isbn)
        {
            var response = await _httpClient.DeleteAsync("api/bookapi/" + isbn);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<int> UpdateBook(Book book)
        {
            var response = await _httpClient.PutAsJsonAsync("api/shopapi/", book);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }
    }
}
