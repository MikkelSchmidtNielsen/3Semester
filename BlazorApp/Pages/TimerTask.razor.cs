using BlazorApp.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Pages
{
    public partial class TimerTask
    {
        private bool _showTaskAssignmentFour;
        private bool _showTaskAssignmentFive;

        public List<Todo> Tasks { get; set; } = new List<Todo>() { 
            new Todo { Name = "Analysis", Time = 40 }, 
            new Todo { Name = "Design", Time = 30 },
            new Todo { Name = "Implementation", Time = 75 }
        };

        private int TotalTime => Tasks.Sum(t => t.Time);

        public Todo TodoModel { get; set; } = new Todo();

        private void UpdateTime(Todo todo, int newTime)
        {
            todo.Time = newTime;
        }

        private void OnDeleteTask(Todo task)
        {
            Tasks.Remove(task);
        }

        private void HandleValidSubmit()
        {
            Tasks.Add(TodoModel);

            TodoModel = new Todo();
        }

        private void HandleInvalidSubmit()
        {
            Console.WriteLine("HandleInvalidSubmit Called...");
        }

        /* Opgave 3: Tilføj delete task funktionalitet */
        private void ShowAssignmentThree()
        {
            _showAssignmentThree = !_showAssignmentThree;
        }

        [CascadingParameter(Name = "ShowAssignmentThree")]
        public bool _showAssignmentThree { get; set; }

        /* Opgave 4: Cascading values */
        private void ShowAssignmentFour()
        {
            _showTaskAssignmentFour = !_showTaskAssignmentFour;
        }

        [CascadingParameter(Name = "TextStyle")]
        public string TextStyle { get; set; } = "color: red";

        [CascadingParameter(Name = "AddButtonText")]
        public string AddButtonText { get; set; } = "+1 Add minute";

        [CascadingParameter(Name = "SubtractButtonText")]
        public string SubtractButtonText { get; set; } = "-1 Subtract minute";

        /* Opgave 5: Form input til at lave nye Tasks */
        private void ShowAssignmentFive()
        {
            _showTaskAssignmentFive = !_showTaskAssignmentFive;
        }

        public void AddTask(string name, int time)
        {
            Tasks.Add(new Todo { Name = name, Time = time });
        }

        /* Opgave 6: Update task titel */
        [CascadingParameter(Name = "ShowAssignmentSix")]
        public bool _showAssignmentSix { get; set; }

        private void ShowAssignmentSix()
        {
            _showAssignmentSix = !_showAssignmentSix;
        }
    }
}
