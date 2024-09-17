using Dino.ForumApp.Application.DTOs;
using Dino.ForumApp.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Dino.ForumApp.Application.Hubs
{
    /// <summary>
    /// SignalR hub for managing real-time communication in the forum.
    /// </summary>
    public class ForumHub : Hub, IForumHub
    {
        private readonly IHubContext<ForumHub> _hubContext;

        public ForumHub(IHubContext<ForumHub> hubContext)
        {
            this._hubContext = hubContext;
        }

        /// <summary>
        /// Broadcasts a new post to all connected clients.
        /// </summary>
        /// <param name="post">The new post.</param>
        public async Task SendPost(PostDto post)
        {
            // Broadcast the new post to all connected clients
            await _hubContext.Clients.All.SendAsync("ReceivePost", post);
        }

        /// <summary>
        /// Broadcasts a new comment to all connected clients.
        /// </summary>
        /// <param name="comment">The new comment of some post.</param>
        public async Task SendComment(CommentDto comment)
        {
            // Broadcast the new comment to all connected clients
            await _hubContext.Clients.All.SendAsync("ReceiveComment", comment);
        }
    }
}
