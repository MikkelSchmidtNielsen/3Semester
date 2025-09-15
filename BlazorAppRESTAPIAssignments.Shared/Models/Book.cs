using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppRESTAPIAssignments.Shared.Models
{
    public class Book
    {
        public string Isbn { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }

        public Book(string isbn, int year, string author, string title)
        {
            Isbn = isbn;
            Year = year;
            Author = author;
            Title = title;
        }
    }
}
