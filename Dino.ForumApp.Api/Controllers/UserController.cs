using Dino.ForumApp.Application.DTOs;
using Dino.ForumApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Dino.ForumApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegistrationDto registrationDto)
        {
            var registrationResponse = await _userService.RegisterAsync(registrationDto);

            if (!registrationResponse.IsSuccess)
            {
                return BadRequest(registrationResponse.Message);
            }

            return Ok(new 
            { 
                Token = registrationResponse.Token, 
                UserName = registrationResponse.UserName 
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var loginResponse = await _userService.LoginAsync(loginDto);

            if (string.IsNullOrEmpty(loginResponse.Token)) 
            { 
                return Unauthorized(loginResponse.Message); 
            }

            return Ok(new 
            { 
                Token = loginResponse.Token, 
                UserName = loginResponse.UserName
            });
        }
    }
}
