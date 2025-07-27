using EduHistoryAI.Core.Dtos;
using EduHistoryAI.Infrastructure.Services.AuthServices;
using EduHistoryAI.Infrastructure.Services.ChatServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduHistoryAI.Web.Controllers
{
    public class ChatController : BaseController
    {
        private readonly IChatService _chatService;

        public ChatController(IAuthService auth, IChatService chatService)
            : base(auth)
        {
            _chatService = chatService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Start(int figureId)
        {
            var sessionId = await _chatService.StartChat(userId, figureId);
            return RedirectToAction("Session", new { sessionId });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Session(int sessionId)
        {
            var session = await _chatService.GetSession(sessionId);
            return View(session);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var aiResponse = await _chatService.SendUserMessageAndGetAIReply(dto.SessionId, dto.MessageText, dto.FigureName);

            return Json(new { success = true, aiMessage = aiResponse });
        }
    }
}
