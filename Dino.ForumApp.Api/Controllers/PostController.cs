using Dino.ForumApp.Application.DTOs;
using Dino.ForumApp.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dino.ForumApp.Api.Controllers
{
    /// <summary>
    /// API Controller for managing post operations.
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostController"/> class.
        /// </summary>
        /// <param name="postService">The post service.</param>
        public PostController(IPostService postService)
        {
            this._postService = postService;
        }

        /// <summary>
        /// Creates a new post.
        /// </summary>
        /// <param name="postDto">The post data transfer object (DTO).</param>
        /// <returns>An action result.</returns>
        [HttpPost("createpost")]
        public async Task<IActionResult> CreatePost(PostDto postDto)
        {
            await _postService.CreatePostAsync(postDto);            

            return Ok();
        }

        /// <summary>
        /// Gets all posts.
        /// </summary>
        /// <returns>An action result with object containing posts list.</returns>
        [HttpGet("posts")]
        public async Task<IActionResult> GetAllPosts()
        {
            GetAllPostsResponse allPostsResponse = await _postService.GetAllPostsAsync();

            return Ok(allPostsResponse);
        }

        /// <summary>
        /// Creates a new comment.
        /// </summary>
        /// <param name="commentDto">The post data transfer object (DTO).</param>
        /// <returns>An action result.</returns>
        [HttpPost("createcomment")]
        public async Task<IActionResult> CreateComment(CommentDto commentDto)
        {
            await _postService.CreateCommentAsync(commentDto);

            return Ok();
        }
    }
}
