using EduHistoryAI.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EduHistoryAI.Data
{
    public class EduHistoryAIDbContext : IdentityDbContext<ApplicationUser>
    {
        public EduHistoryAIDbContext(DbContextOptions<EduHistoryAIDbContext> options) : base(options) { }

        public DbSet<HistoricalFigure> HistoricalFigures { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<ChatSession> ChatSessions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }

}
