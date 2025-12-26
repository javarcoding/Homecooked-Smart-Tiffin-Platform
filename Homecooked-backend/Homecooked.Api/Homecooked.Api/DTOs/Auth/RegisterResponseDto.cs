namespace Homecooked.Api.DTOs.Auth
{
    public class RegisterResponseDto
    {
        public Guid UserId { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public required string Message { get; set; }
    }
}
