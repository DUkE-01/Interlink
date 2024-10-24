using Microsoft.AspNetCore.Mvc;

namespace Interlink.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
