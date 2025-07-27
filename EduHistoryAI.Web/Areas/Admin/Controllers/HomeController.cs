using EduHistoryAI.Infrastructure.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;

namespace EduHistoryAI.Web.Areas.Admin.Controllers
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
    }
}
