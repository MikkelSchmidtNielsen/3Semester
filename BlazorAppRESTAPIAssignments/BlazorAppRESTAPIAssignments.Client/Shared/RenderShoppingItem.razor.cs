using BlazorAppRESTAPIAssignments.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAppRESTAPIAssignments.Client.Shared
{
    public partial class RenderShoppingItem
    {
        [Parameter, EditorRequired]
        public ShoppingItem ShoppingItemModel { get; set; }


    }
}
