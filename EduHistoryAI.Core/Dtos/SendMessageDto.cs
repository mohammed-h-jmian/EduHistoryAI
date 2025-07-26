using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Core.Dtos
{
   
        public class SendMessageDto
        {
        public int Id { get; set; }

        public string Sender { get; set; } = "User";
        public string FigureName { get; set; }

        public string MessageText { get; set; } = string.Empty;

        public int SessionId { get; set; }
        }


}
