using FractalBookStore.Domain.Services;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Get Model of data the for a Razor page.
        /// </summary>
        /// <param name="query">query for search</param>
        /// <returns> Model of data - Book[]</returns>
        public IActionResult Index(string query)
        {
            var books = _bookService.GetAllByQuery(query);

            return View(books);
        }
    }
}
