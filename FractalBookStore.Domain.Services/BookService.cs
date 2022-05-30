using FractalBookStore.DTOFactory;
using System;
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

        public async Task<Book[]> GetAllByQueryAsync(string query)
        {
            if(BookDTOFactory.IsIsbn(query))
                return await _bookRepository.GetAllByIsbnAsync(query);
            return await _bookRepository.GetAllByTitleOrAuthorAsync(query);
        }
    }
}
