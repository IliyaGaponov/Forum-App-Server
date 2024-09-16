using Dino.ForumApp.DataAccess.Interfaces;
using Dino.ForumApp.Domain.Models;
using Dino.ForumApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dino.ForumApp.DataAccess.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ForumDbContext _dbContext;

        public CommentRepository(ForumDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
