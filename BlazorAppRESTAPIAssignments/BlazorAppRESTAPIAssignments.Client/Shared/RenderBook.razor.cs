using BlazorAppRESTAPIAssignments.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAppRESTAPIAssignments.Client.Shared
{
    public partial class RenderBook
    {
        [Parameter, EditorRequired]
        public Book BookModel { get; set; }
    }
}
