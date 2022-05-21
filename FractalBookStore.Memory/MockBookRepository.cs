using System;
using System.Collections.Generic;
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
            new Book(1, "ISBN 12345-12340", "Fractals: a very short introduction", "Alex Jonson",
                        "VERY SHORT INTRODUCTIONS are for anyone wanting a stimulating and accessible way in to a new"
                        +"subject. They are written by experts, and have been published in more than 25 languages worldwide."
                        +"The series began in 1995, and now represents a wide variety of topics in history, philosophy, religion,"
                        +"science, and the humanities.", 13.19m),

            new Book(2, "ISBN 12345-12341", "The Fractal Geometry Of Nature", "Max Steveson", "The Fractal Geometry...", 19.13m),
            new Book(3, "ISBN 12345-12342", "The Colors Of Infinity", "William Richardson", "The Colors...", 13.13m),
            new Book(4, "ISBN 12345-12343", "Fractal Nature Of Life", "John Holly", "Fractal Nature...", 19.19m),
            new Book(5, "ISBN 12345-12344", "Fractal And Multifractals","Steve Rest", "Fractal And Multifractals...", 113.19m),
            new Book(6, "ISBN 12345-12345", "Introduction To Fractal Theory", "Jack Hardy", "Introduction To Fractal Theory...", 119.13m),
            new Book(7, "ISBN 12345-12346", "Fractals In Geomechanics", "Mark Jackson", "Fractals In Geomechanics...", 113.13m),
            new Book(8, "ISBN 12345-12347", "Fractals Phisics of Self-Similarity", "Carl Lotty", "Fractals Phisics...", 119.19m),
            new Book(9, "ISBN 12345-12348", "Beauty Of Fractals", "Mark Departh", "Beauty Of Fractals...", 3.9m),
            new Book(10, "ISBN 12345-12349", "Basics Of Fractal Geometry", "Tracy Horny", "Basics Of Fractal...", 3.3m),
            new Book(11, "ISBN 12345-12350", "Just A Fractal", "Anton Galitch", "Just A Fractal...", 9.3m),
            new Book(12, "ISBN 12345-12351", "Fractal Between Myth And Craft", "Peter Garryson", "Fractal Between Myth...", 9.9m),
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
                                    || book.Title.Contains(query)
                                    || book.Description.Contains(query))
                                    .ToArray();
        }
        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;
            return foundBooks.ToArray();
        }
    }
}
