using Microsoft.AspNetCore.Components;
using BlazorApp.Models;

namespace BlazorApp.Shared
{
    public partial class RenderTimeTask
    {
        [Parameter, EditorRequired]
        public Todo Task { get; set; }

        [Parameter, EditorRequired]
        public EventCallback<int> OnMinutesChanged { get; set; }

        [Parameter, EditorRequired]
        public EventCallback<Todo> OnDeleteTask { get; set; }

        private async Task AddMinute()
        {
            Task.Time++;
            await OnMinutesChanged.InvokeAsync(Task.Time);
        }

        private async Task SubtractMinute()
        {
            if (Task.Time > 0)
            {
                Task.Time--;
                await OnMinutesChanged.InvokeAsync(Task.Time);
            }
        }

        private async Task DeleteTaskClicked()
        {
            await OnDeleteTask.InvokeAsync(Task);
        }

        /* Opgave 3: Tilføj delete task funktionalitet */
        [CascadingParameter(Name = "ShowAssignmentThree")]
        public bool _showAssignmentThree { get; set; }

        /* Opgave 4: Cascading values */
        [CascadingParameter(Name = "TextStyle")]
        public string TextStyle { get; set; }

        [CascadingParameter(Name = "AddButtonText")]
        public string AddButtonText { get; set; }

        [CascadingParameter(Name = "SubtractButtonText")]
        public string SubtractButtonText { get; set; }

        /* Opgave 6: Update task titel */
        private string _newTaskTitel;

        private void UpdateTaskTitel()
        {
            Task.Name = _newTaskTitel;
        }

        [CascadingParameter(Name = "ShowAssignmentSix")]
        public bool _showAssignmentSix { get; set; }
    }
}
