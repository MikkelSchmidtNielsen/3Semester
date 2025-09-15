using BlazorAppRESTAPIAssignments.Client.Services;
using BlazorAppRESTAPIAssignments.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAppRESTAPIAssignments.Client.Pages
{
	public partial class AddShoppingItem
	{
		[Inject]
		public IShoppingService ShoppingService { get; set; }
		public ShoppingItem ShoppingItemModel { get; set; } = new ShoppingItem();
		private int ErrorCode { get; set; } = 0;

		private async Task AddShoppingItemHandler(ShoppingItem item)
		{
			ErrorCode = await ShoppingService.AddItem(item);

			ShoppingItemModel = new ShoppingItem();

			Console.WriteLine("Shopping item added: return code: " + ErrorCode);
		}
	}
}
