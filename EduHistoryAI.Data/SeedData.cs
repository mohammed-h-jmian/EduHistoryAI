using EduHistoryAI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<EduHistoryAIDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await context.Database.MigrateAsync();

            await SeedRolesAsync(roleManager);
            await SeedAdminUserAsync(userManager);
            await SeedHistoricalFiguresAsync(context);

        }

        private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Admin", "Teacher", "Student" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        private static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            string adminEmail = "admin@eduhistoryai.com";
            string adminPassword = "Admin@123";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin",
                    FullName = "System Admin",
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }

        private static async Task SeedHistoricalFiguresAsync(EduHistoryAIDbContext context)
        {
            if (!context.HistoricalFigures.Any())
            {
                var figures = new List<HistoricalFigure>
                {
                    new HistoricalFigure
                    {
                        Name = "صلاح الدين الأيوبي",
                        Description = "القائد الذي حرر القدس في معركة حطين عام 1187.",
                        ImageUrl = "/uploads/salah-aldin.jpg"
                    },
                    new HistoricalFigure
                    {
                        Name = "أبو بكر الصديق",
                        Description = "الخليفة الأول وأحد أقرب الصحابة إلى الرسول ﷺ.",
                        ImageUrl = "/uploads/abu-bakr.jpg"
                    }
                };

                await context.HistoricalFigures.AddRangeAsync(figures);
                await context.SaveChangesAsync();
            }
        }

       
    }
}
