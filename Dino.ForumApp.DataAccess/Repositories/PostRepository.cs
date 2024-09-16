using Dino.ForumApp.DataAccess.Interfaces;
using Dino.ForumApp.Domain.Models;
using Dino.ForumApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dino.ForumApp.DataAccess.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ForumDbContext _dbContext;

        public PostRepository(ForumDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddPostAsync(Post post)
        {
            await _dbContext.Posts.AddAsync(post).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> IsPostExists(int postId)
        {
            return await _dbContext.Posts.AnyAsync(p => p.Id == postId).ConfigureAwait(false);
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _dbContext.Posts.Include(c => c.Comments).Include(p => p.Author).ToListAsync().ConfigureAwait(false);
        }
    }
}
