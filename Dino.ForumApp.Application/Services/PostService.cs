using AutoMapper;
using Dino.ForumApp.Application.DTOs;
using Dino.ForumApp.Application.Interfaces;
using Dino.ForumApp.DataAccess.Interfaces;
using Dino.ForumApp.Domain.Models;

namespace Dino.ForumApp.Application.Services
{
    /// <summary>
    /// Service for managing post-related operations.
    /// </summary>
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IForumHub _forumHub;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostService"/> class.
        /// </summary>
        /// <param name="postRepository">The post repository.</param>
        /// <param name="commentRepository">The comment repository.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="mapper">The automapper.</param>
        /// <param name="forumHub">The signalr hub.</param>
        public PostService(IPostRepository postRepository, ICommentRepository commentRepository, IUserRepository userRepository, IMapper mapper, IForumHub forumHub)
        {
            this._postRepository = postRepository;
            this._commentRepository = commentRepository;
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._forumHub = forumHub;
        }

        /// <summary>
        /// Creates a new post.
        /// </summary>
        /// <param name="postDto">The post data transfer object (DTO) containing post details.</param>
        public async Task CreatePostAsync(PostDto postDto)
        {
            // Verify whether the user exists
            User user = await _userRepository.GetUserByEmailAsync(postDto.Email).ConfigureAwait(false);

            Post post = _mapper.Map<Post>(postDto, opt =>
            {
                opt.Items["AuthorId"] = user.Id;
            });

            postDto.Id = await _postRepository.AddPostAsync(post).ConfigureAwait(false);

            // Broadcast the new post to all clients via SignalR
            await _forumHub.SendPost(postDto);
        }

        /// <summary>
        /// Gets all posts.
        /// </summary>
        /// <returns>Returns all forum posts.</returns>
        public async Task<GetAllPostsResponse> GetAllPostsAsync()
        {
            List<Post> posts = await _postRepository.GetAllPostsAsync().ConfigureAwait(false);
            List<PostResponse> postsResponse = _mapper.Map<List<PostResponse>>(posts);

            return new GetAllPostsResponse { Posts = postsResponse };
        }

        /// <summary>
        /// Creates a new comment.
        /// </summary>
        /// <param name="commentDto">The comment data transfer object (DTO) containing comment details.</param>
        public async Task CreateCommentAsync(CommentDto commentDto)
        {
            // Verify whether a post exists for this comment
            if (await _postRepository.IsPostExists(commentDto.PostId))
            {
                User user = await _userRepository.GetUserByEmailAsync(commentDto.Email).ConfigureAwait(false);
                Comment comment = _mapper.Map<Comment>(commentDto, opt =>
                {
                    opt.Items["AuthorId"] = user.Id;
                });

                await _commentRepository.AddCommentAsync(comment).ConfigureAwait(false);

                // Broadcast the new post to all clients via SignalR
                await _forumHub.SendComment(commentDto);
            }
        }
    }
}
