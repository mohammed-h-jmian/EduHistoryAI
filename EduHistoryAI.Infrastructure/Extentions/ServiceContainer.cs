using EduHistoryAI.Infrastructure.Services.AuthServices;
using EduHistoryAI.Infrastructure.Services.ChatServices;
using EduHistoryAI.Infrastructure.Services.FileServices;
using EduHistoryAI.Infrastructure.Services.GoogleGeminiServices;
using EduHistoryAI.Infrastructure.Services.HistoricalFigureServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace EduHistoryAI.Infrastructure.Extentions
{

    public static class ServiceContainer
    {
        public static IServiceCollection AddConfig(
        this IServiceCollection services, IConfiguration config)
        {

            return services;
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IHistoricalFigureService, HistoricalFigureService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IGoogleGeminiService, GoogleGeminiService>();
            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
