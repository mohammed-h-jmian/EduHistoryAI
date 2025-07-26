using EduHistoryAI.Core.Dtos.AuthDtos;
using EduHistoryAI.Core.ViewModels;
using EduHistoryAI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Infrastructure.Services.AuthServices
{
    public interface IAuthService
    {
        Task<(bool Succeeded, string[] Errors)> RegisterAsync(RegisterDto model);
        Task<(bool Succeeded, string Error)> LoginAsync(LoginDto model);
        Task LogoutAsync();
        ApplicationUserViewModel? GetUserByUsername(string username);

    }
}
