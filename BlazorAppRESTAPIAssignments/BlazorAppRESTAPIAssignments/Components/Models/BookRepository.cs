using BlazorAppRESTAPIAssignments.Shared.Models;
using System.Security.Cryptography;

namespace BlazorAppRESTAPIAssignments.Components.Models
{
    public class BookRepository : IBookRepository
    {
        private static readonly List<Book> _books;

        static BookRepository()
        {
            _books = new List<Book>();
            _books.Clear();
            InsertTestData();
        }

        public static void InsertTestData()
        {
            _books.Add(new Book("9788-70221-2123", 2003, "J.K. Rowling", "Harry Potter og Fønixordenen"));
            _books.Add(new Book("9788-77137-2068", 1954, "J.R.R. Tolkien", "Ringenes Herre: Eventyret om Ringen"));
            _books.Add(new Book("9788-70224-2755", 1865, "Lewis Carroll", "Alice i Eventyrland"));
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
            Console.WriteLine("AddBook is called!");
        }

        //return item with id = -1 if not found
        public Book FindBook(string Isbn)
        {
            foreach (var book in _books)
            {
                if (book.Isbn == Isbn)
                    return book;
            }
            return null;
        }

        public bool UpdateBook(Book book)
        {
            Book oldBook = _books.FirstOrDefault(x => x.Isbn == book.Isbn);

            if (oldBook != null)
            {
                oldBook.Title = book.Title;
                oldBook.Author = book.Author;
                oldBook.Year = book.Year;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteBook(string Isbn)
        {
            Book FoundBook = FindBook(Isbn);
            if (FoundBook != null)
            {
                _books.Remove(FoundBook);
                return true;
            }
            else return false;
        }

        public List<Book> GetAllBooks()
        {
            return _books;
        }
    }
}
