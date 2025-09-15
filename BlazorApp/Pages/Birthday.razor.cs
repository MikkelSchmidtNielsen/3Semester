using BlazorApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp.Pages
{
    public partial class Birthday
    {
        private InviteAnswer InvitationModel = new InviteAnswer();

        public List<InviteAnswer> AnswerList = new List<InviteAnswer>();

        private void HandleValidSubmit()
        {
            AnswerList.Add(InvitationModel); // Tilføjer

            InvitationModel = new InviteAnswer(); // Laver en ny instans (ren form)
        }

        private void HandleInvalidSubmit()
        {
            Console.WriteLine("HandleInvalidSubmit Called...");
        }

        private void HandleShortCut(KeyboardEventArgs e)
        {
            if ((e.Key == "m" || e.Key == "M") && e.CtrlKey)
            {
                InvitationModel.Name = "John Doe";
                InvitationModel.Email = "mail@example.dk";
                InvitationModel.IsComing = true;
                InvitationModel.Attendants = 2;
            }

            if ((e.Key == "z" || e.Key == "Z") && e.CtrlKey)
            {
                InvitationModel.Name = "Konrad";
                InvitationModel.Email = "mail@example.dk";
                InvitationModel.IsComing = false;
                InvitationModel.Attendants = 0;
            }
        }
    }
}
