using Dino.ForumApp.Application.DTOs;

namespace Dino.ForumApp.Application.Interfaces
{
    public interface IForumHub
    {
        Task SendComment(CommentDto comment);
        Task SendPost(PostDto post);
    }
}