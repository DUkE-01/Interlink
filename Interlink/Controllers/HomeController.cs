using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Application.ViewModels.Post;
using Interlink.Middlewares;
using Interlink.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Interlink.Controllers
{
    public class HomeController : Controller
    {
        private readonly ValidateUserSession _validateUserSession;
        private readonly IPostService _postService;


        public HomeController(ValidateUserSession validateUserSession, IPostService postService)
        {
            _validateUserSession = validateUserSession;
            _postService = postService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            var posts = await _postService.GetAllViewModelWithInclude();

            if (posts == null || !posts.Any())
            {
                posts = new List<PostViewModel>();
            }
            return View(posts);
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
