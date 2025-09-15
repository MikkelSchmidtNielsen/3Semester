using BlazorAppRESTAPIAssignments.Shared.Models;

namespace BlazorAppRESTAPIAssignments.Components.Models
{
    public interface IShoppingRepository
    {
        List<ShoppingItem> GetAllItems();
        ShoppingItem FindItem(int id);
        void AddItem(ShoppingItem item);
        bool DeleteItem(int id);
        bool UpdateItem(ShoppingItem item);
    }
}
