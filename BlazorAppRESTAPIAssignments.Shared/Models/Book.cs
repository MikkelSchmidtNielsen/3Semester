using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppRESTAPIAssignments.Shared.Models
{
    public class Book
    {
        [Required(ErrorMessage = "ISBN skal udfyldes")]
        public string? Isbn { get; set; }

        [Required(ErrorMessage = "Year skal udfyldes")]
        [Range(1, int.MaxValue, ErrorMessage = "Year skal være større end 0")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Author skal udfyldes")]
        public string? Author { get; set; }

        [Required(ErrorMessage = "Titel skal udfyldes")]
        public string? Title { get; set; }

        public Book()
        {
        }

        public Book(string isbn, int year, string author, string title)
        {
            Isbn = isbn;
            Year = year;
            Author = author;
            Title = title;
        }
    }
}
