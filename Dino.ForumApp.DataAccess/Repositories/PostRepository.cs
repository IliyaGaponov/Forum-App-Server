using Dino.ForumApp.DataAccess.Interfaces;
using Dino.ForumApp.Domain.Models;
using Dino.ForumApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dino.ForumApp.DataAccess.Repositories
{
    /// <summary>
    /// Repository for accessing post data.
    /// </summary>
    public class PostRepository : IPostRepository
    {
        private readonly ForumDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public PostRepository(ForumDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Adds a new post to the database.
        /// </summary>
        /// <param name="post">The post entity.</param>
        /// <returns>Returns the Id of created post.</returns>
        public async Task<int> AddPostAsync(Post post)
        {
            await _dbContext.Posts.AddAsync(post).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return post.Id; // Retrieve the ID after the product is added  
        }

        /// <summary>
        /// Verifies wheather a post exists by postid.
        /// </summary>
        /// <param name="postId">The postid of the post.</param>
        /// <returns>Returns boolean value of existing.</returns>
        public async Task<bool> IsPostExists(int postId)
        {
            return await _dbContext.Posts.AsNoTracking().AnyAsync(p => p.Id == postId).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves all forum posts.
        /// </summary>
        /// <returns>Returns all posts.</returns>
        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _dbContext.Posts.Include(c => c.Comments).Include(p => p.Author).ToListAsync().ConfigureAwait(false);
        }
    }
}
