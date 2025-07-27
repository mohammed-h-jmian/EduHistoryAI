using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Core.ViewModels
{
    public class ChatMessageViewModel
    {
        public int Id { get; set; }

        public string Sender { get; set; } = "User";

        public string MessageText { get; set; } 

        public DateTime SentAt { get; set; }

        public int ChatSessionId { get; set; }
        public ChatSessionViewModel? ChatSession { get; set; }
    }
}
