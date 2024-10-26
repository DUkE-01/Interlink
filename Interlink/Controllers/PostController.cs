using Microsoft.AspNetCore.Mvc;
using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Application.ViewModels.Post;
using Interlink.Core.Application.ViewModels.Search;
using Interlink.Core.Application.ViewModels.Home;
using Interlink.Middlewares;

namespace Interlink.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ValidateUserSession _validateUserSession;

        public PostController(IPostService postService, ValidateUserSession validateUserSession)
        {
            _postService = postService;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            var viewModel = new HomeViewModel
            {
                Posts = await _postService.GetAllViewModelWithInclude(),
                NewPost = new SavePostViewModel()
            };

            return View(viewModel); 
        }


        public async Task<IActionResult> Create(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            return View(new SavePostViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePostViewModel vm, string userId)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            await _postService.Add(vm, userId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            SavePostViewModel vm = await _postService.GetByIdSaveViewModel(id);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePostViewModel vm, string UserId)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            await _postService.Update(vm, vm.UserId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            return View(await _postService.GetByIdSaveViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            await _postService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
