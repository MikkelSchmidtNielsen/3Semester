using BlazorApp.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorApp.Pages
{
    public partial class ProductPage
    {
        private Product ProductModel = new Product();

        private List<Product> ProductList = new List<Product>();

        private string[] ProductMaterials = {"", "Træ", "Plastik", "Metal"};

        protected override void OnInitialized()
        {
            ProductModel.Material = ProductMaterials[0];
        }

        private void HandleValidSubmit()
        {
            ProductList.Add(ProductModel); // Tilføjer produktet

            ProductModel = new Product(); // Laver en ny instans af product (ren form)

            ProductModel.Material = ProductMaterials[0];
        }

        private void HandleInvalidSubmit()
        {
            Console.WriteLine("HandleInvalidSubmit Called...");
        }

        private void ClearProductList()
        {
            if (ProductList.Count > 0)
            {
                ProductList.Clear();
            }
        }
    }
}
