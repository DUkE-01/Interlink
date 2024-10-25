using Microsoft.AspNetCore.Mvc;

namespace Interlink.Controllers
{
    public class CommentReplyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
