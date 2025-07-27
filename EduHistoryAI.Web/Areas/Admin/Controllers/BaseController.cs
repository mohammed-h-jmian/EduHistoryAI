using EduHistoryAI.Infrastructure.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EduHistoryAI.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaseController : Controller
    {
        private readonly IAuthService _authService;
        protected string userId;
        public BaseController(IAuthService authService)
        {
            _authService = authService;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (User.Identity.IsAuthenticated)
            {
                try
                {
                    var userName = User.Identity.Name;
                    var user = _authService.GetUserByUsername(userName);

                    if (user != null)
                    {
                        userId = user.Id;
                        ViewBag.UserId = user.Id;
                        ViewBag.FullName = user.FullName;

                        //ViewBag.ImageUrl = user.ImageUrl;

                    }
                    else
                    {
                        Redirect("/Base/DeleteUser");
                    }
                }
                catch (Exception)
                {


                }
            }
        }


        public IActionResult NotFound()
        {
            return View();
        }
    }
}