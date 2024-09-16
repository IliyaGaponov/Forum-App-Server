using Dino.ForumApp.Application.DTOs;

namespace Dino.ForumApp.Application.Interfaces
{
    public interface IPostService
    {
        Task<GetAllPostsResponse> GetAllPostsAsync();
        Task CreatePostAsync(PostDto post);
        Task CreateCommentAsync(CommentDto comment);
    }
}
