using Homecooked.Api.Data;
using Homecooked.Api.DTOs.Auth;
using Homecooked.Api.Interfaces;
using Homecooked.Api.Models;
using Homecooked.Api.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Homecooked.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtHelper _jwtHelper;


        public AuthService(ApplicationDbContext context, JwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }

        public async Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (existingUser != null)
                throw new Exception("Email already registered");

            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = PasswordHasher.HashPassword(request.Password),
                Role = request.Role,
                IsActive = true,
                IsVerified = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new RegisterResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                Role = user.Role.ToString(),
                Message = "Registration successful"
            };
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null || !PasswordHasher.VerifyPassword(request.Password, user.PasswordHash))
            {
                throw new Exception("Invalid email or password");
            }

            if (!user.IsActive)
                throw new Exception("User is blocked");

            var token = _jwtHelper.GenerateToken(user.Id, user.Role.ToString(), user.Email);

            return new LoginResponseDto
            {
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString(),
                Token = token
            };
        }
    }
}
