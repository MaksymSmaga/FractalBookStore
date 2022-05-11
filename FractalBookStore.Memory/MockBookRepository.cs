using System.Linq;

namespace FractalBookStore.Memory
{
    // To implement IBookRepository of Domain Layer
    // by Class BookRepository with test data.

    public class MockBookRepository : IBookRepository
    {
        // Array of test data.
        private readonly Book[] books = new[]
        {
            new Book(1, "Fractals: a very short introduction"),
            new Book(2, "The Fractal Geometry Of Nature"),
            new Book(3, "The Colors Of Infinity"),
            new Book(4, "Fractal Nature Of Life"),
            new Book(5, "Fractal And Multifractals"),
            new Book(6, "Introduction To Fractal Theory"),
            new Book(7, "Fractals In Geomechanics"),
            new Book(8, "Fractals Phisics of Self-Similarity"),
            new Book(9, "Beauty Of Fractals"),
            new Book(10, "Basics Of Fractal Geometry"),
            new Book(11, "Just A Fractal"),
            new Book(12, "Fractal Between Myth And Craft"),
        };

        /// <summary>
        ///  Get all books by title.
        /// </summary>
        /// <param name="titlePart"></param>
        /// <returns>Array Book[]</returns>
        public Book[] GetAllByTitle(string titlePart)
        { 
            return books.Where(book => book.Title.Contains(titlePart)).ToArray();
        }
    }
}
