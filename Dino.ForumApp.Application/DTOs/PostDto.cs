namespace Dino.ForumApp.Application.DTOs
{
    public class PostDto
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string Email { get; set; }
        public string? UserName { get; set; }
    }
}
