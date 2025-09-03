using System.ComponentModel.DataAnnotations;
using System.Data;

namespace EditFormsAndValidation.Components.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Navn skal være mindre end 50 bogstaver langt")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
