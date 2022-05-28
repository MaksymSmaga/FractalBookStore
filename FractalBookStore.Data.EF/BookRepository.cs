using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FractalBookStore.Data.EF
{
    class BookRepository : IBookRepository
    {
        private readonly DbContextFactory _dBContextFactory;

        public BookRepository(DbContextFactory dBContextFactory)
        {
            _dBContextFactory = dBContextFactory;
        }

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var dbContext = _dBContextFactory.Create(typeof(BookRepository));

            return dbContext.Books
                            .Where(book => bookIds.Contains(book.Id))
                            .AsEnumerable()
                            .Select(Book.Mapper.Map)
                            .ToArray();
        }

        public Book[] GetAllByIsbn(string isbn)
        {
            var dbContext = _dBContextFactory.Create(typeof(BookRepository));

            if (Book.TryFormatedIsbn(isbn, out string formatedIsbn))
            {
                return dbContext.Books
                            .Where(book => book.Isbn == formatedIsbn)
                            .AsEnumerable()
                            .Select(Book.Mapper.Map)
                            .ToArray();
            }
            return new Book[0];
        }

        public Book[] GetAllByTitleOrAuthor(string titleOrAuthor)
        {
            var dbContext = _dBContextFactory.Create(typeof(BookRepository));

            if (String.IsNullOrEmpty(titleOrAuthor)) titleOrAuthor = "Fractals";
          
            var parameter = new SqlParameter("@titleOrAuthor", titleOrAuthor);

            return dbContext.Books
                        .FromSqlRaw(                 
                        "SELECT * FROM Books WHERE Title LIKE '%" + titleOrAuthor + "%'" +
                                             " OR Author LIKE '%" + titleOrAuthor + "%'", parameter)
                        .AsEnumerable()
                        .Select(Book.Mapper.Map)
                        .ToArray();
        }

        public Book GetById(int id)
        {
            var dbContext = _dBContextFactory.Create(typeof(BookRepository));

            var dto = dbContext.Books
                .Single(book => book.Id == id);
            return Book.Mapper.Map(dto);
        }
    }
}
