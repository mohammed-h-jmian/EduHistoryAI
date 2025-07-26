using System.Diagnostics;
using EduHistoryAI.Data.Models;
using EduHistoryAI.Infrastructure.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace EduHistoryAI.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(IAuthService auth, ILogger<HomeController> logger) : base(auth)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
