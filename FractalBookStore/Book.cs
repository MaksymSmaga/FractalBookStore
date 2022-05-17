using System.Text.RegularExpressions;

namespace FractalBookStore
{
    // To realize an entity of Business Logic
    // with help class Book.
    public class Book
    {
        public int Id { get; }
        public string Isbn { get; }
        public string Author { get; }
        public string Title { get; }
        public Book(int id, string isbn, string title, string author)
        {
            Id = id;
            Isbn = isbn;
            Title = title;
            Author = author;
        }

        public static bool IsIsbn(string s)
        {
            if (s == null)
                return false;

            s = s.Replace("-", "")
                 .Replace(" ", "")
                 .ToUpper();

            return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");
        }
    }
}
