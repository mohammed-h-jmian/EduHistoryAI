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
        Task<int> StartChatAsync(string studentId, int historicalFigureId);
        Task<ChatSessionViewModel> GetSessionAsync(int sessionId);
        Task AddMessageAsync(int sessionId, string sender, string messageText);
        Task<string> SendUserMessageAndGetAIReplyAsync(int sessionId, string userMessage, string figureName);
    }
}
