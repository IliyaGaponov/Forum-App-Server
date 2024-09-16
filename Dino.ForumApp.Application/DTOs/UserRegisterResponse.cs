namespace Dino.ForumApp.Application.DTOs
{
    public record UserRegisterResponse
    {
        public bool IsSuccess { get; init; }
        public string? Message { get; init; }
        public required string UserName { get; init; }
        public string? Token { get; init; }

    }
}
