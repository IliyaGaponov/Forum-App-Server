using Dino.ForumApp.Domain.Models;

namespace Dino.ForumApp.Application.Interfaces.Auth
{
    /// <summary>
    /// Provides the contract for generating and validating JWT tokens.
    /// </summary>
    public interface IJwtProvider
    {
        /// <summary>
        /// Generates a JWT token for the specified user.
        /// </summary>
        /// <param name="user">The auth user.</param>
        /// <returns>Returns a JWT token string.</returns>
        string GenerateToken(User user);
    }
}
