using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FractalBookStore
{
    // To describe the contract functional
    // of inheritanced and implemented BookRepositories.
    public interface IBookRepository
    {
        Task<Book[]> GetAllByIsbnAsync(string titlePart);

        Task<Book[]> GetAllByTitleOrAuthorAsync(string titleOrAuthor);

        Task<Book> GetByIdAsync(int id);

        Task<Book[]> GetAllByIdsAsync(IEnumerable<int> bookIds);

        Task<Decimal> GetLowPrice();

        Task<Decimal> GetHighPrice();

        Task<Book> GetNewest();

        Task<Book> GetRandomRecommended();

        Task<Book> GetCheapest();

        Task<Book> GetDiscountest();
    }
}
