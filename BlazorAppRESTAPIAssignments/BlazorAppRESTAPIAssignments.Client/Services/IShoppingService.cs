using BlazorAppRESTAPIAssignments.Shared.Models;

namespace BlazorAppRESTAPIAssignments.Client.Services
{
    public interface IShoppingService
    {
        Task<ShoppingItem[]?> GetAllItems();
        Task<ShoppingItem?> GetItem(int id);
        Task<int> AddItem(ShoppingItem item);
        Task<int> DeleteItem(int id);
        Task<int> UpdateItem(ShoppingItem item);
    }
}
