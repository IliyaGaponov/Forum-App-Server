namespace Dino.ForumApp.Application.Interfaces.Auth
{
    public interface IPasswordHasher
    {
        string Generate(string paasword);
        bool Verify(string password, string hashedPassword);
    }
}