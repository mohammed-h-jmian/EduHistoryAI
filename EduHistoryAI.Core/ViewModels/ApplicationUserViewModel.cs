using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Core.ViewModels
{
    public class ApplicationUserViewModel
    {
        [Required]
        public string? Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? FullName { get; set; }
        //public string? ImageUrl { get; set; }
        public ICollection<ChatSessionViewModel> ChatSessions { get; set; }
    }
}
