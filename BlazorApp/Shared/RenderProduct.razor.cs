using Microsoft.AspNetCore.Components;
using BlazorApp.Models;

namespace BlazorApp.Shared
{
    public partial class RenderProduct
    {
        [Parameter, EditorRequired]
        public Product Product { get; set; }
    }
}
