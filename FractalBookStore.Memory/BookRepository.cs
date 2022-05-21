using System;
using System.Collections.Generic;
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

        public Book[] GetAllByIsbn(string titlePart)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  Get all books by title.
        /// </summary>
        /// <param name="titlePart"></param>
        /// <returns>Array Book[]</returns>
        public Book[] GetAllByTitleOrAuthor(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart)).ToArray();
        }

        public Book GetById(int id)
        {
            return books.Single(book=>book.Id == id);
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
