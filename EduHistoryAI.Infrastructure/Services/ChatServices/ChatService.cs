using AutoMapper;
using EduHistoryAI.Core.ViewModels;
using EduHistoryAI.Data;
using EduHistoryAI.Data.Models;
using EduHistoryAI.Infrastructure.Services.GoogleGeminiServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EduHistoryAI.Infrastructure.Services.ChatServices
{
    public class ChatService : IChatService
    {
        private readonly EduHistoryAIDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGoogleGeminiService _geminiService;

        public ChatService(EduHistoryAIDbContext context, IMapper mapper, IGoogleGeminiService geminiService)
        {
            _context = context;
            _mapper = mapper;
            _geminiService = geminiService;
        }

        public async Task<int> StartChat(string userId, int historicalFigureId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("StudentId cannot be null or empty.", nameof(userId));
            }

            // auto mapper

            var session = new ChatSession
            {
                StudentId = userId,
                HistoricalFigureId = historicalFigureId,
                StartedAt = DateTime.UtcNow,
                LastActivityAt = DateTime.UtcNow
            };

            _context.ChatSessions.Add(session);
            await _context.SaveChangesAsync();
            return session.Id;
        }

        public async Task<ChatSessionViewModel> GetSession(int sessionId)
        {
            var session = await _context.ChatSessions
                .Include(s => s.HistoricalFigure)
                .Include(s => s.Messages)
                .Include(s=>s.Student)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == sessionId);

            if (session == null)
            {
                throw new KeyNotFoundException($"Chat session with ID {sessionId} not found.");
            }
            return _mapper.Map<ChatSessionViewModel>(session);
        }

        public async Task AddMessage(int sessionId, string sender, string messageText)
        {
            if (string.IsNullOrEmpty(sender))
                throw new ArgumentException("Sender cannot be null or empty.", nameof(sender));
            if (string.IsNullOrEmpty(messageText))
                throw new ArgumentException("MessageText cannot be null or empty.", nameof(messageText));

            var session = await _context.ChatSessions.FindAsync(sessionId);
            if (session == null)
                throw new KeyNotFoundException($"Chat session with ID {sessionId} not found.");

            session.LastActivityAt = DateTime.UtcNow;

            var message = new ChatMessage
            {
                ChatSessionId = sessionId,
                Sender = sender,
                MessageText = messageText,
                SentAt = DateTime.UtcNow
            };

            _context.ChatMessages.Add(message);
            await _context.SaveChangesAsync();
        }

        //public async Task<string> SendUserMessageAndGetAIReplyAsync(int sessionId, string userMessage, string figureName)
        //{
        //    await AddMessageAsync(sessionId, "User", userMessage);
        //    var aiPrompt = $"You are {figureName}, a historical figure. Answer like {figureName}. User said: {userMessage}";
        //    var aiReply = await _geminiService.GenerateContentAsync(aiPrompt);
        //    await AddMessageAsync(sessionId, "AI", aiReply);

        //    return aiReply;
        //}
        public async Task<string> SendUserMessageAndGetAIReply(int sessionId, string userMessage, string figureName)
        {
            await AddMessage(sessionId, "User", userMessage);

            bool isArabic = System.Text.RegularExpressions.Regex.IsMatch(userMessage, @"\p{IsArabic}");

            string aiPrompt;
            if (isArabic)
            {
                aiPrompt = $"أنت {figureName}، شخصية تاريخية. أجب مثل {figureName}. قال المستخدم: {userMessage}";
            }
            else
            {
                aiPrompt = $"You are {figureName}, a historical figure. Answer like {figureName}. User said: {userMessage}";
            }

            var aiReply = await _geminiService.GenerateContent(aiPrompt);
            await AddMessage(sessionId, "AI", aiReply);

            return aiReply;
        }

        public async Task<IEnumerable<ChatSessionViewModel>> GetAllSessions()
        {
            var sessions = await _context.ChatSessions
                .Include(s => s.Student)
                .Include(s => s.HistoricalFigure)
                .Include(s => s.Messages)
                .AsNoTracking()
                .OrderByDescending(s => s.LastActivityAt)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ChatSessionViewModel>>(sessions);
        }
     
    }
}
