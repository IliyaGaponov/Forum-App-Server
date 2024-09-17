namespace Dino.ForumApp.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when a user is alredy exists in the system.
    /// </summary>
    public class UserAlreadyExistsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAlreadyExistsException"/> class.
        /// </summary>
        public UserAlreadyExistsException() : base("User already exists.") { }
    }
}
