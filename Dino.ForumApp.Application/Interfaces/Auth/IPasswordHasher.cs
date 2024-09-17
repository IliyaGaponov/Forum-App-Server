namespace Dino.ForumApp.Application.Interfaces.Auth
{
    /// <summary>
    /// Provides the contract for hashing and verifying passwords.
    /// </summary>
    public interface IPasswordHasher
    {
        /// <summary>
        /// Hashes the specified password using a cryptographic hash function.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>Returns the hashed password.</returns>
        string Generate(string paasword);

        // <summary>
        /// Verifies a password against a hashed password.
        /// </summary>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <param name="password">The password provided for verification.</param>
        /// <returns>Returns a boolean indicating whether the password matches the hash.</returns>
        bool Verify(string password, string hashedPassword);
    }
}