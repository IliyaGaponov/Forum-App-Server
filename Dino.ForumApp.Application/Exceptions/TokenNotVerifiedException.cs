namespace Dino.ForumApp.Application.Exceptions
{
    /// <summary>
    /// Exception thrown when token not verified.
    /// </summary>
    public class TokenNotVerifiedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenNotVerifiedException"/> class.
        /// </summary>
        public TokenNotVerifiedException() : base("Token verification failed.")
        {
        }
    }
}
