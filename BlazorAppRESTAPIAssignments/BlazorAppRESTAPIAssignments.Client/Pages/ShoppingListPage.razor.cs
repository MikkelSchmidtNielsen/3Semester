using BlazorAppRESTAPIAssignments.Client.Services;
using BlazorAppRESTAPIAssignments.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Threading.Tasks;

namespace BlazorAppRESTAPIAssignments.Client.Pages
{
    public partial class ShoppingListPage
    {
        private List<ShoppingItem> Items = new List<ShoppingItem>();

        private ShoppingItem ShoppingItemModel { get; set; } = new ShoppingItem();

        private int ErrorCode { get; set; } = 0;

        private bool _showUpdateForm;

		protected override async Task OnInitializedAsync()
        {
            var shoppingItems = await _shoppingService.GetAllItems();

            if (shoppingItems != null)
            {
                Items = shoppingItems.ToList();
            }
        }

        private async Task DeleteSelectedIdHandler(int id)
        {
			ErrorCode = (await _shoppingService.DeleteItem(id));

			Console.WriteLine($"Id selected to delete {id}, responsecode: {ErrorCode} ");

			if (ErrorCode == (int)HttpStatusCode.OK)
			{
				Items = (await _shoppingService.GetAllItems()).ToList();
			}
		}

        public void GetUpdateForm(ShoppingItem item)
        {
            _showUpdateForm = true;

            ShoppingItemModel = item;
		}

        public async Task UpdateShoppingItem()
        {
			ErrorCode = (await _shoppingService.UpdateItem(ShoppingItemModel));

			Console.WriteLine($"Id selected to update {ShoppingItemModel.Id}, responsecode: {ErrorCode} ");

			if (ErrorCode == (int)HttpStatusCode.OK)
			{
				Items = (await _shoppingService.GetAllItems()).ToList();
			}
		}

	}
}
