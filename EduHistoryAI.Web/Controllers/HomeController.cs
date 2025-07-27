using System.Diagnostics;
using EduHistoryAI.Data.Models;
using EduHistoryAI.Infrastructure.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace EduHistoryAI.Web.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IAuthService auth) : base(auth)
        {
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
