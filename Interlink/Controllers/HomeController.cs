using Interlink.Middlewares;
using Interlink.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Interlink.Controllers
{
    public class HomeController : Controller
    {
        private readonly ValidateUserSession _validateUserSession;

        public HomeController(ValidateUserSession validateUserSession)
        {
            _validateUserSession = validateUserSession;
        }

        public IActionResult Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Amigos()
        {
            return View();
        }
        public IActionResult Chats()
        {
            return View();
        }
        public IActionResult Buscar()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
