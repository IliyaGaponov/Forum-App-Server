using Dino.ForumApp.DataAccess.Interfaces;
using Dino.ForumApp.Domain.Models;
using Dino.ForumApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Dino.ForumApp.DataAccess.Repositories
{
    /// <summary>
    /// Repository for accessing user data.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ForumDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UserRepository(ForumDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Adds a new user to the database.
        /// </summary>
        /// <param name="user">The user entity.</param>
        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves a user by their email.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns>Returns the user entity.</returns>
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == email).ConfigureAwait(false);
        }

        /// <summary>
        /// Verifies wheather user exists by email.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns>Returns boolean value.</returns>
        public async Task<bool> IsUserExists(string email)
        {
            return await _dbContext.Users.AsNoTracking().AnyAsync(u => u.Email == email).ConfigureAwait(false);
        }
    }
}
