using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Core.Dtos
{
    public class ChatMessageDto
    {
        public string Sender { get; set; } = "User";
        public string MessageText { get; set; }
    }
}
