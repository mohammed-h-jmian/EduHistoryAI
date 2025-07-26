
namespace EduHistoryAI.Core.ViewModels
{
    public class HistoricalFigureViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public ICollection<ChatSessionViewModel> ChatSessions { get; set; } = new List<ChatSessionViewModel>();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public String? CreatedById { get; set; }
        public ApplicationUserViewModel CreatedBy { get; set; }
    }
}
