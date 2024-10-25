using Interlink.Core.Application.Interfaces.Services;
using Interlink.Core.Application.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
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
            var posts = await _postService.GetAllViewModelWithInclude();
            return View(posts);
        }

        public async Task<IActionResult> Create()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            SavePostViewModel vm = new();
            vm.Content = (await _postService.GetAllViewModel()).FirstOrDefault()?.Content;
            vm.CreatedAt = (await _postService.GetAllViewModel()).FirstOrDefault()?.CreatedAt ?? DateTime.Now;
            return View("SavePost", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePostViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                vm.Content = (await _postService.GetAllViewModel()).FirstOrDefault()?.Content;
                return View("SavePost", vm);
            }

            string userId = User.Identity.Name;
            SavePostViewModel postVm = await _postService.Add(vm, userId);

            return RedirectToRoute(new { controller = "Post", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            SavePostViewModel vm = await _postService.GetByIdSaveViewModel(id);
            vm.Content = (await _postService.GetAllViewModel()).FirstOrDefault()?.Content;
            vm.CreatedAt = (await _postService.GetAllViewModel()).FirstOrDefault()?.CreatedAt ?? DateTime.Now;
            return View("SavePost", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePostViewModel vm, int id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            if (!ModelState.IsValid)
            {
                vm.Content = (await _postService.GetAllViewModel()).FirstOrDefault()?.Content;
                return View("SavePost", vm);
            }

            await _postService.Update(vm, id);
            return RedirectToRoute(new { controller = "Post", action = "Index" });
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

            string basePath = $"/Images/Products/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (Directory.Exists(path))
            {
                DirectoryInfo directory = new(path);

                foreach (FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo folder in directory.GetDirectories())
                {
                    folder.Delete(true);
                }

                Directory.Delete(path);
            }

            return RedirectToRoute(new { controller = "Post", action = "Index" });
        }
    }
}
