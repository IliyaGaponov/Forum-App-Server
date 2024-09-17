using Dino.ForumApp.Application.Interfaces.Auth;

namespace Dino.ForumApp.Infrastructure
{
    /// <summary>
    /// Provides functionality for hashing and verifying passwords.
    /// </summary>
    public class PasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// Hashes the specified password using a cryptographic hash function.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>Returns the hashed password.</returns>
        public string Generate(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        // <summary>
        /// Verifies a password against a hashed password.
        /// </summary>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <param name="password">The password provided for verification.</param>
        /// <returns>Returns a boolean indicating whether the password matches the hash.</returns>
        public bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
        }
    }
}
