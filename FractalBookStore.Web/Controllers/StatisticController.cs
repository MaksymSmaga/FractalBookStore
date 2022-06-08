using Microsoft.AspNetCore.Mvc;

namespace FractalBookStore.Web.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
