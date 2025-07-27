using EduHistoryAI.Core.ViewModels;
using EduHistoryAI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Infrastructure.Services.ChatServices
{
    public interface IChatService
    {
        Task<int> StartChat(string studentId, int historicalFigureId);
        Task<ChatSessionViewModel> GetSession(int sessionId);
        Task AddMessage(int sessionId, string sender, string messageText);
        Task<string> SendUserMessageAndGetAIReply(int sessionId, string userMessage, string figureName);
        Task<IEnumerable<ChatSessionViewModel>> GetAllSessions();
    }

}
