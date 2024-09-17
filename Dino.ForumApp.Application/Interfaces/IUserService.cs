using Dino.ForumApp.Application.DTOs;

namespace Dino.ForumApp.Application.Interfaces
{
    /// <summary>
    /// Defines the contract for user-related operations.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Logins a user.
        /// </summary>
        /// <param name="loginDto">The login data transfer object (DTO) containing user login information.</param>
        /// <returns>Returns the token and username of the logged in user.</returns>
        Task<UserLoginResponse> LoginAsync(UserLoginDto userLoginDto);

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="registrationDto">The register data transfer object (DTO) containing user register information.</param>
        /// <returns>Returns the token and username of the newly created user.</returns>
        Task<UserRegisterResponse> RegisterAsync(UserRegistrationDto registrationDto);
    }
}