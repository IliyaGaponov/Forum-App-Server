using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dino.ForumApp.Infrastructure
{
    public static class AuthOptions
    {
        public const string ISSUER = "ForumAppServer";
        public const string AUDIENCE = "ForumApp"; 
        const string KEY = "mysupersecret_secretsecretsecretkey!123";
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
