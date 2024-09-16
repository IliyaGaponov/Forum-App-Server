using System.ComponentModel.DataAnnotations.Schema;

namespace Dino.ForumApp.Domain.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Content { get; set; }
        public required DateTime CreatedAt { get; set; }
        public int? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public required User Author { get; set; }
        public int? PostId { get; set; }
        [ForeignKey("PostId")]
        public required Post Post { get; set; }
    }
}
