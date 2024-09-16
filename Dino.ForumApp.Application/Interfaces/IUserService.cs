using Dino.ForumApp.Application.DTOs;

namespace Dino.ForumApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserLoginResponse> LoginAsync(UserLoginDto userLoginDto);
        Task<UserRegisterResponse> RegisterAsync(UserRegistrationDto userRegistration);
    }
}