using AutoMapper;
using Dino.ForumApp.Application.DTOs;
using Dino.ForumApp.Application.Hubs;
using Dino.ForumApp.Application.Interfaces;
using Dino.ForumApp.DataAccess.Interfaces;
using Dino.ForumApp.Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace Dino.ForumApp.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IForumHub _forumHub;

        public PostService(IPostRepository postRepository, ICommentRepository commentRepository, IUserRepository userRepository, IMapper mapper, IForumHub forumHub)
        {
            this._postRepository = postRepository;
            this._commentRepository = commentRepository;
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._forumHub = forumHub;
        }       

        public async Task CreatePostAsync(PostDto postDto)
        {
            User user = await _userRepository.GetUserByEmailAsync(postDto.Email).ConfigureAwait(false);

            Post post = _mapper.Map<Post>(postDto, opt =>
            {
                opt.Items["AuthorId"] = user.Id;
            });

            await _postRepository.AddPostAsync(post).ConfigureAwait(false);

            // Broadcast the new post to all clients via SignalR
            //await _hubContext.Clients.All.SendAsync("ReceivePost", postDto);
            await _forumHub.SendPost(postDto);
        }

        public async Task<GetAllPostsResponse> GetAllPostsAsync()
        {
            List<Post> posts = await _postRepository.GetAllPostsAsync().ConfigureAwait(false);
            List<PostResponse> postsResponse = _mapper.Map<List<PostResponse>>(posts);

            return new GetAllPostsResponse { Posts = postsResponse };
        }

        public async Task CreateCommentAsync(CommentDto commentDto)
        {
            if (await _postRepository.IsPostExists(commentDto.PostId))
            {
                User user = await _userRepository.GetUserByEmailAsync(commentDto.Email).ConfigureAwait(false);
                Comment comment = _mapper.Map<Comment>(commentDto, opt =>
                {
                    opt.Items["AuthorId"] = user.Id;
                });

                await _commentRepository.AddCommentAsync(comment).ConfigureAwait(false);

                // Broadcast the new post to all clients via SignalR
                //await _hubContext.Clients.All.SendAsync("ReceiveComment", commentDto);
                await _forumHub.SendComment(commentDto);
            }
        }
    }
}
