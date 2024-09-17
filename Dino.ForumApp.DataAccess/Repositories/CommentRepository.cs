using Dino.ForumApp.DataAccess.Interfaces;
using Dino.ForumApp.Domain.Models;
using Dino.ForumApp.Infrastructure.Data;

namespace Dino.ForumApp.DataAccess.Repositories
{
    /// <summary>
    /// Repository for accessing comment data.
    /// </summary>
    public class CommentRepository : ICommentRepository
    {
        private readonly ForumDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CommentRepository(ForumDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Adds a new comment to the database.
        /// </summary>
        /// <param name="comment">The comment entity.</param>
        public async Task AddCommentAsync(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
