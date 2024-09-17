namespace Dino.ForumApp.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when credentials failed.
    /// </summary>
    public class CredentialsFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CredentialsFailedException"/> class.
        /// </summary>
        public CredentialsFailedException() : base("Credentials verification failed.") { }
    }
}
