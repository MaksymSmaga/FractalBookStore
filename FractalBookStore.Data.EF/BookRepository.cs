using FractalBookStore.DTO;
using FractalBookStore.DTOFactory;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FractalBookStore.Data.EF
{
    class BookRepository : IBookRepository
    {
        private readonly DbContextFactory _dBContextFactory;

        public BookRepository(DbContextFactory dBContextFactory)
        {
            _dBContextFactory = dBContextFactory;
        }

        public async Task<Book[]> GetAllByIsbnAsync(string isbn)
        {
            var dbContext = _dBContextFactory.Create(typeof(BookRepository));

            if (BookDTOFactory.TryFormatedIsbn(isbn, out string formatedIsbn))
            {
                var dtos = await dbContext.Books
                            .Where(book => book.Isbn == formatedIsbn)
                            .ToArrayAsync();

                return dtos.Select(Mapper.Map)
                            .ToArray();
            }
            return new Book[0];
        }

        public async Task<Book[]> GetAllByIdsAsync(IEnumerable<int> bookIds)
        {
            var dbContext = _dBContextFactory.Create(typeof(BookRepository));

            var dtos = await dbContext.Books
                            .Where(book => bookIds.Contains(book.Id))
                            .ToArrayAsync();

            return dtos.Select(Mapper.Map)
                           .ToArray();
        }

        public async Task<Book[]> GetAllByTitleOrAuthorAsync(string titleOrAuthor)
        {
            var dbContext = _dBContextFactory.Create(typeof(BookRepository));

            if (String.IsNullOrEmpty(titleOrAuthor))
                titleOrAuthor = "";

            var parameter = new SqlParameter("@titleOrAuthor", titleOrAuthor);

            var dtos = await dbContext.Books
                        .FromSqlRaw(
                        "SELECT * FROM Books WHERE Title LIKE '%" + titleOrAuthor + "%'" +
                                             " OR Author LIKE '%" + titleOrAuthor + "%'", parameter)
                        .ToArrayAsync();

            return dtos.Select(Mapper.Map)
                         .ToArray();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var dbContext = _dBContextFactory.Create(typeof(BookRepository));

            var dto = await dbContext.Books
                            .SingleAsync(book => book.Id == id);
            return Mapper.Map(dto);
        }

    }    
}
