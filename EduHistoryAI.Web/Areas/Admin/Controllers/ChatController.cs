using EduHistoryAI.Infrastructure.Services.AuthServices;
using EduHistoryAI.Infrastructure.Services.ChatServices;
using Microsoft.AspNetCore.Mvc;

namespace EduHistoryAI.Web.Areas.Admin.Controllers
{
    public class ChatController : BaseController
    {
        private readonly IChatService _chatService;

        public ChatController(IAuthService auth, IChatService chatService)
            : base(auth)
        {
            _chatService = chatService;
        }
        public async Task<IActionResult> Index()
        {
            var sessions = await _chatService.GetAllSessions();
            return View(sessions);
        }
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var session = await _chatService.GetSession(id);
                return View(session);
            }
            catch
            {
                return RedirectToAction("NotFound", "Base", new { area = "Admin" });
            }
        }
    }
}
