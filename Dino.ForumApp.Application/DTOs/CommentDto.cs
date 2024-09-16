namespace Dino.ForumApp.Application.DTOs
{
    public class CommentDto
    {
        public required string Content { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string Email { get; set; }
        public string? UserName { get; set; }
        public required int PostId { get; set; }
    }
}
