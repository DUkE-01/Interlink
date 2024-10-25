using Microsoft.AspNetCore.Mvc;

namespace Interlink.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
