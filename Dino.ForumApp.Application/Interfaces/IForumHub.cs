using Dino.ForumApp.Application.DTOs;

namespace Dino.ForumApp.Application.Interfaces
{
    /// <summary>
    /// SignalR hub for managing real-time communication in the forum.
    /// </summary>
    public interface IForumHub
    {
        /// <summary>
        /// Broadcasts a new comment to all connected clients.
        /// </summary>
        /// <param name="comment">The new comment of some post.</param>
        Task SendComment(CommentDto comment);

        // <summary>
        /// Broadcasts a new post to all connected clients.
        /// </summary>
        /// <param name="post">The new post.</param>
        Task SendPost(PostDto post);
    }
}