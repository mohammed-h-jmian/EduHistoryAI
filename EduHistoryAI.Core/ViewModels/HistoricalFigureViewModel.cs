
namespace EduHistoryAI.Core.ViewModels
{
    public class HistoricalFigureViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<ChatSessionViewModel> ChatSessions { get; set; } = new List<ChatSessionViewModel>();

        public DateTime CreatedAt { get; set; }
        public String? CreatedById { get; set; }
        public ApplicationUserViewModel CreatedBy { get; set; }
    }
}
