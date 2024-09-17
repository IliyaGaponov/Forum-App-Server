using Dino.ForumApp.Application.DTOs;
using Dino.ForumApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Dino.ForumApp.Api.Controllers
{
    // <summary>
    /// API Controller for managing user operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="registrationDto">The user data transfer object (DTO).</param>
        /// <returns>An action result indicating the outcome of the operation.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto registrationDto)
        {
            var registrationResponse = await _userService.RegisterAsync(registrationDto);

            if (!registrationResponse.IsSuccess)
            {
                return BadRequest(registrationResponse.Message);
            }

            return Ok(registrationResponse);
        }

        /// <summary>
        /// Logins a new user.
        /// </summary>
        /// <param name="loginDto">The user data transfer object (DTO).</param>
        /// <returns>An action result indicating the outcome of the operation.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var loginResponse = await _userService.LoginAsync(loginDto);

            if (string.IsNullOrEmpty(loginResponse.Token)) 
            { 
                return Unauthorized(loginResponse.Message); 
            }

            return Ok(loginResponse);
        }
    }
}
