using System.ComponentModel.DataAnnotations.Schema;

namespace Dino.ForumApp.Domain.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public required User Author { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
