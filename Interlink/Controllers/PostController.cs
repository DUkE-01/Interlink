using Microsoft.AspNetCore.Mvc;

namespace Interlink.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
