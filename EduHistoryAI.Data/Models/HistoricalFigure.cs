using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Data.Models
{
    public class HistoricalFigure
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<ChatSession> ChatSessions { get; set; } = new List<ChatSession>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public String? CreatedById { get; set; } 
        public ApplicationUser CreatedBy { get; set; }
    }
}
