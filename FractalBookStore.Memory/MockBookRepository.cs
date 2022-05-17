using System;
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
            new Book(1, "ISBN 12345-12340", "Alex Jonson","Fractals: a very short introduction", "Fractals: a very...", 13.19m),
            new Book(2, "ISBN 12345-12341", "Max Steveson","The Fractal Geometry Of Nature", "The Fractal Geometry...", 19.13m),
            new Book(3, "ISBN 12345-12342", "William Richardson","The Colors Of Infinity", "The Colors...", 13.13m),
            new Book(4, "ISBN 12345-12343", "John Holly","Fractal Nature Of Life", "Fractal Nature...", 19.19m),
            new Book(5, "ISBN 12345-12344", "Steve Rest","Fractal And Multifractals", "Fractal And Multifractals...", 113.19m),
            new Book(6, "ISBN 12345-12345", "Jack Hardy","Introduction To Fractal Theory", "Introduction To Fractal Theory...", 119.13m),
            new Book(7, "ISBN 12345-12346", "Mark Jackson","Fractals In Geomechanics", "Fractals In Geomechanics...", 113.13m),
            new Book(8, "ISBN 12345-12347", "Carl Lotty","Fractals Phisics of Self-Similarity", "Fractals Phisics...", 119.19m),
            new Book(9, "ISBN 12345-12348", "Mark Departh","Beauty Of Fractals", "Beauty Of Fractals...", 3.9m),
            new Book(10, "ISBN 12345-12349", "Tracy Horny","Basics Of Fractal Geometry", "Basics Of Fractal...", 3.3m),
            new Book(11, "ISBN 12345-12350", "Anton Galitch","Just A Fractal", "Just A Fractal...", 9.3m),
            new Book(12, "ISBN 12345-12351", "Peter Garryson","Fractal Between Myth And Craft", "Fractal Between Myth...", 9.9m),
        };
        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }
        /// <summary>
        ///  Get all books by title.
        /// </summary>
        /// <param name="titlePart"></param>
        /// <returns>Array Book[]</returns>
        public Book[] GetAllByTitleOrAuthor(string query)
        { 
            return books.Where(book => book.Author.Contains(query)
                                    || book.Author.Contains(query))
                                    .ToArray();
        }


      
    }
}
