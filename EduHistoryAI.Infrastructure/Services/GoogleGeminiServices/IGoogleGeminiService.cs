using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Infrastructure.Services.GoogleGeminiServices
{
    public interface IGoogleGeminiService
    {
        Task<string> GenerateContent(string userMessage);
    }
}
