namespace Dino.ForumApp.Application.Exceptions
{
    public class TokenNotVerifiedException : Exception
    {
        public TokenNotVerifiedException() : base("Token verification failed.")
        {
        }
    }
}
