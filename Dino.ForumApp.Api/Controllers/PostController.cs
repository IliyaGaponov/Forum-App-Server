using Dino.ForumApp.Application.DTOs;
using Dino.ForumApp.Application.Interfaces;
using Dino.ForumApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Dino.ForumApp.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            this._postService = postService;
        }

        [HttpPost("createpost")]
        public async Task<IActionResult> CreatePost(PostDto postDto)
        {
            await _postService.CreatePostAsync(postDto);            

            return Ok();
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetAllPosts()
        {
            GetAllPostsResponse allPostsResponse = await _postService.GetAllPostsAsync();

            return Ok(allPostsResponse);
        }

        [HttpPost("createcomment")]
        public async Task<IActionResult> CreateComment(CommentDto commentDto)
        {
            await _postService.CreateCommentAsync(commentDto);

            return Ok();
        }
    }
}
