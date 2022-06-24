using FractalBookStore.DTOFactory;
using FractalBookStore.Web.Models.Pages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FractalBookStore.Domain.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book[]> GetAllByQueryAsync(string query, int bookPage = 1)
        {
            int PageSize = 3;

            new BookListViewModel
            {
                Books = _bookRepository.Books
                              .OrderBy(b => b.Id)
                              .Skip((bookPage - 1) * PageSize)
                              .Take(PageSize),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = bookPage,
                    ItemsPerPage = PageSize,
                    TotalItems = _bookRepository.Books.Count()
                }
            };


            if (BookDTOFactory.IsIsbn(query))
                return await _bookRepository.GetAllByIsbnAsync(query);
            return await _bookRepository.GetAllByTitleOrAuthorAsync(query);
        }
    }
}
