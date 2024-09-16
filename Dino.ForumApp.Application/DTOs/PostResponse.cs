using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dino.ForumApp.Application.DTOs
{
    public class PostResponse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string Email { get; set; }
        public string? UserName { get; set; }
        public List<CommentDto>? Comments { get; set; }
    }
}
