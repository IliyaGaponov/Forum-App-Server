using Dino.ForumApp.DataAccess.Interfaces;
using Dino.ForumApp.Domain.Models;
using Dino.ForumApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dino.ForumApp.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ForumDbContext _dbContext;

        public UserRepository(ForumDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email).ConfigureAwait(false);
        }

        public async Task<bool> IsUserExists(string email)
        {
            return await _dbContext.Users.AnyAsync(u => u.Email == email).ConfigureAwait(false);
        }
    }
}
