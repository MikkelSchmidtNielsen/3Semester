using BlazorApp.Models;

namespace BlazorApp.Pages
{
    public partial class Birthday
    {
        private int _pictureIndex = 0;

        private InviteAnswer InvitationModel = new InviteAnswer();

        public List<InviteAnswer> AnswerList = new List<InviteAnswer>();

        private void HandleValidSubmit()
        {
            AnswerList.Add(InvitationModel); // Tilføjer produktet

            InvitationModel = new InviteAnswer(); // Laver en ny instans af product (ren form)
        }

        private void HandleInvalidSubmit()
        {
            Console.WriteLine("HandleInvalidSubmit Called...");
        }
    }
}
