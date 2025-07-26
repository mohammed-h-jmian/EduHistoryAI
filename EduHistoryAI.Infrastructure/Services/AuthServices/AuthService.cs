using AutoMapper;
using EduHistoryAI.Core.Dtos.AuthDtos;
using EduHistoryAI.Core.ViewModels;
using EduHistoryAI.Data;
using EduHistoryAI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Infrastructure.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly EduHistoryAIDbContext _context;
        private readonly IMapper _mapper;
        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper, EduHistoryAIDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _context = context;
        }

        public async Task<(bool Succeeded, string[] Errors)> RegisterAsync(RegisterDto model)
        {
            if (model.Password != model.ConfirmPassword)
                return (false, new[] { "Passwords do not match." });



            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            return (result.Succeeded, result.Errors.Select(e => e.Description).ToArray());
        }

        public async Task<(bool Succeeded, string Error)> LoginAsync(LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            return result.Succeeded ? (true, string.Empty) : (false, "Invalid login attempt.");
        }

        public ApplicationUserViewModel? GetUserByUsername(string username)
        {
            var user = _context.Users
                .SingleOrDefault(x => x.UserName == username );
            return _mapper.Map<ApplicationUserViewModel>(user);
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
