using System.ComponentModel.DataAnnotations;

namespace Dino.ForumApp.Application.DTOs
{
    public record UserRegistrationDto
    {
        public required string UserName { get; init; }
        [EmailAddress]
        public required string Email { get; init; }
        public required string Password { get; init; }
    }
}
