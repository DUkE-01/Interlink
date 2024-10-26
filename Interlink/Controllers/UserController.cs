using Interlink.Core.Application.Interfaces.Services;
using Interlink.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Interlink.Core.Application.ViewModels.User;
using Interlink.Core.Application.Helpers;


namespace Interlink.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly ValidateUserSession _validateUserSession;

        public UserController(IUserService userService, ValidateUserSession validateUserSession)
        {
            _userService = userService;
            _validateUserSession = validateUserSession;
        }

      
        public IActionResult Index()
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel vm)
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
           
            UserViewModel userVm = await _userService.Login(vm);
            if (userVm != null)
            {
                HttpContext.Session.Set<UserViewModel>("user", userVm);
                return RedirectToAction( "Index", "Home");
            }

            else
            {
                ModelState.AddModelError("userValidation", "Datos de acceso incorrectos");
            }

            return View(vm);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        [HttpGet]
        public IActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel vm, string userId)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            await _userService.Add(vm, userId);
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        [HttpGet]
        public IActionResult Perfil()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Ajustes()
        {
            return View();
        }
    }
}


