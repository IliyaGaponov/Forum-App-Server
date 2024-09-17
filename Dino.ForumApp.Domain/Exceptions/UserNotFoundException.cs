namespace Dino.ForumApp.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when a user is not found in the system.
    /// </summary>
    public class UserNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserNotFoundException"/> class.
        /// </summary>
        public UserNotFoundException() : base("User not found.") { }
    }
}
