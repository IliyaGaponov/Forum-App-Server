using System.ComponentModel.DataAnnotations;

namespace Dino.ForumApp.Application.DTOs
{
    public record UserLoginDto
    {
        [EmailAddress]
        public required string Email { get; init; }
        public required string Password { get; init; }
    }
}
