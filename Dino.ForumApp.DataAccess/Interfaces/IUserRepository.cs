using Dino.ForumApp.Domain.Models;

namespace Dino.ForumApp.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsUserExists(string email);
        Task AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
    }
}
