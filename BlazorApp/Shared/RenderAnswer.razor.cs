using Microsoft.AspNetCore.Components;
using BlazorApp.Models;

namespace BlazorApp.Shared
{
    public partial class RenderAnswer
    {
        [Parameter, EditorRequired]
        public InviteAnswer Answer { get; set; }

        [Parameter, EditorRequired]
        public int PictureIndex { get; set; }
    }
}
