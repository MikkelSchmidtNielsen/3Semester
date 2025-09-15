using BlazorAppRESTAPIAssignments.Shared.Models;

namespace BlazorAppRESTAPIAssignments.Client.Pages
{
    public partial class ShoppingListPage
    {
        private List<ShoppingItem> Items = new List<ShoppingItem>();

        protected override async Task OnInitializedAsync()
        {
            var shoppingItems = await _shoppingService.GetAllItems();

            if (shoppingItems != null)
            {
                Items = shoppingItems.ToList();
            }
        }
    }
}
