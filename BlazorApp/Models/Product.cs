using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Navnet skal være mindre end 50 tegn.")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }
        
        public string Material { get; set; }

        public bool IsPublished { get; set; }

        public DateTime PublishedDate { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"Varenavn: {Name}, Pris: {Price}";
        }
    }
}
