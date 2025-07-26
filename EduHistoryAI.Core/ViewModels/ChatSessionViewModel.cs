using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Core.ViewModels
{
    public class ChatSessionViewModel
    {
        public int Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public ApplicationUserViewModel Student { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastActivityAt { get; set; }
        public int HistoricalFigureId { get; set; }
        public HistoricalFigureViewModel? HistoricalFigure { get; set; }
        public ICollection<ChatMessageViewModel> Messages { get; set; } = new List<ChatMessageViewModel>();
    }
}
