using BlazorAppRESTAPIAssignments.Shared.Models;
using System.Net.Http.Json;

namespace BlazorAppRESTAPIAssignments.Client.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly HttpClient _httpClient;

        public ShoppingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ShoppingItem[]> GetAllItems()
        {
            var result = _httpClient.GetFromJsonAsync<ShoppingItem[]>("api/shopapi");

            return result;
        }

        public async Task<int> AddItem(ShoppingItem item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/shopapi", item);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<ShoppingItem?> GetItem(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ShoppingItem>("api/shopapi/" + id);
            return result;
        }

        public async Task<int> DeleteItem(int id)
        {
            var response = await _httpClient.DeleteAsync("api/shopapi/" + id);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }

        public async Task<int> UpdateItem(ShoppingItem item)
        {
            var response = await _httpClient.PutAsJsonAsync("api/shopapi/", item);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;
        }
    }
}
