using EduHistoryAI.Core.Dtos.AuthDtos;
using EduHistoryAI.Infrastructure.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace EduHistoryAI.Web.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) : base(authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var (succeeded, errors) = await _authService.RegisterAsync(model);

            if (!succeeded)
            {
                foreach (var error in errors)
                    ModelState.AddModelError(string.Empty, error);

                return View(model);
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var (succeeded, error) = await _authService.LoginAsync(model);

            if (!succeeded)
            {
                ModelState.AddModelError(string.Empty, error);
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

