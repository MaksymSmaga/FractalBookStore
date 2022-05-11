using System.Linq;

namespace FractalBookStore.Memory
{
    // To implement IBookRepository of Domain Layer
    // by Class BookRepository with test data.
    // Dependency inversion.
    public class BookRepository : IBookRepository
    {
        // Array of test data.
        private readonly Book[] books;
        public Book[] GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart)).ToArray();
        }
    }
}
