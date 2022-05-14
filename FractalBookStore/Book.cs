namespace FractalBookStore
{
    // To realize an entity of Business Logic
    // with help class Book.
    public class Book
    {
        public int Id { get; }
        public string Title { get; }
        public Book(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public static bool IsIsbn(string s)
        {
            return false;
        }
    }
}
