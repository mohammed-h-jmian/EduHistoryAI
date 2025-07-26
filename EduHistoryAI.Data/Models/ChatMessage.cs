using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Data.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }

        public string Sender { get; set; } = "User";

        public string MessageText { get; set; } = string.Empty;

        public DateTime SentAt { get; set; } = DateTime.UtcNow;

        public int ChatSessionId { get; set; }
        public ChatSession? ChatSession { get; set; }
    }

}
