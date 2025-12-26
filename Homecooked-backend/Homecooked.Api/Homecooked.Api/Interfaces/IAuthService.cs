using Homecooked.Api.DTOs.Auth;

namespace Homecooked.Api.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto request);
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}
