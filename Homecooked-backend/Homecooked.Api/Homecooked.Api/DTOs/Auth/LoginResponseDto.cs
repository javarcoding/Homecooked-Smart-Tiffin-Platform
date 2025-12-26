namespace Homecooked.Api.DTOs.Auth
{
    public class LoginResponseDto
    {
        public Guid UserId { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public required string Token { get; set; }
    }
}
