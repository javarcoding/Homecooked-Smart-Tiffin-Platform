using System.ComponentModel.DataAnnotations;

namespace Homecooked.Api.DTOs.Auth
{
    public class LoginRequestDto
    {
        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required, MinLength(6)]
        public required string Password { get; set; }
    }
}
