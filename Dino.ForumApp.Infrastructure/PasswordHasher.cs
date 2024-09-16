using Dino.ForumApp.Application.Interfaces.Auth;

namespace Dino.ForumApp.Infrastructure
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Generate(string paasword)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(paasword);
        }

        public bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
        }
    }
}
