using Dino.ForumApp.Application.DTOs;

namespace Dino.ForumApp.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for post-related operations.
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Gets all posts.
        /// </summary>
        /// <returns>Returns all forum posts.</returns>
        Task<GetAllPostsResponse> GetAllPostsAsync();

        /// <summary>
        /// Creates a new post.
        /// </summary>
        /// <param name="postDto">The post data transfer object (DTO) containing post details.</param>
        Task CreatePostAsync(PostDto postDto);

        /// <summary>
        /// Creates a new comment.
        /// </summary>
        /// <param name="commentDto">The comment data transfer object (DTO) containing comment details.</param>
        Task CreateCommentAsync(CommentDto commentDto);
    }
}
