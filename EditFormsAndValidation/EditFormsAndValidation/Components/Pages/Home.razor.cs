using EditFormsAndValidation.Components.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace EditFormsAndValidation.Components.Pages
{
    public partial class Home
    {
        private Product ProductModel = new Product();
        private EditContext EditContext;

        protected override void OnInitialized()
        {
            EditContext = new EditContext(ProductModel);
        }

        private void HandleSubmit()
        {
            Console.WriteLine("HandleSubmit called...");

            if (EditContext.Validate())
            {
                Console.WriteLine("Form is valid...");
            }
            else
            {
                Console.WriteLine("Form is invalid...");
            }
        }
    }
}
