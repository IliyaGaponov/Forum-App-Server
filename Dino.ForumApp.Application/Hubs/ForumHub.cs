using Dino.ForumApp.Application.DTOs;
using Dino.ForumApp.Application.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Dino.ForumApp.Application.Hubs
{
    public class ForumHub : Hub, IForumHub
    {
        private readonly IHubContext<ForumHub> _hubContext;

        public ForumHub(IHubContext<ForumHub> hubContext)
        {
            this._hubContext = hubContext;
        }
        public async Task SendPost(PostDto post)
        {
            // Broadcast the new post to all connected clients
            await _hubContext.Clients.All.SendAsync("ReceivePost", post);
        }

        public async Task SendComment(CommentDto comment)
        {
            // Broadcast the new comment to all connected clients
            await _hubContext.Clients.All.SendAsync("ReceiveComment", comment);
        }
    }
}
