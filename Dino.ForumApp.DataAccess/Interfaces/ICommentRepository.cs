using Dino.ForumApp.Domain.Models;

namespace Dino.ForumApp.DataAccess.Interfaces
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);
    }
}
