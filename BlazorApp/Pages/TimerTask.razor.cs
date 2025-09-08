using BlazorApp.Models;
using BlazorApp.Shared;

namespace BlazorApp.Pages
{
    public partial class TimerTask
    {
        public List<Todo> Tasks { get; set; } = new List<Todo>();

        public void AddTask(string name, int time)
        {
            Tasks.Add(new Todo { Name = name, Time = time });
        }
    }
}
