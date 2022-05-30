using FractalBookStore.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FractalBookStore.Web.Controllers
{
    // To declare Controller for working on the request.
    public class SearchController : Controller
    {
        // To get data repository for working on it.
        private readonly BookService _bookService;

        // Injection via constructor.
        public SearchController(BookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index(string query)
        {
            var books = await _bookService.GetAllByQueryAsync(query);

            return View(books);
        }
    }
}
