using AutoMapper;
using Dino.ForumApp.Application.Interfaces;
using Dino.ForumApp.DataAccess.Interfaces;
using Dino.ForumApp.Domain.Models;
using Dino.ForumApp.Application.DTOs;
using Dino.ForumApp.Application.Interfaces.Auth;
using Dino.ForumApp.Domain.Exceptions;
using Dino.ForumApp.Application.Exceptions;

namespace Dino.ForumApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._passwordHasher = passwordHasher;
            this._jwtProvider = jwtProvider;
            this._mapper = mapper;
        }

        public async Task<UserRegisterResponse> RegisterAsync(UserRegistrationDto registrationDto)
        {
            if (await _userRepository.IsUserExists(registrationDto.Email).ConfigureAwait(false))
            {
                throw new UserAlreadyExistsException();
            }
            var hashedPassword = _passwordHasher.Generate(registrationDto.Password);

            User user = _mapper.Map<User>(registrationDto, opt =>
            {
                opt.Items["PasswordHash"] = hashedPassword;
            });

            await _userRepository.AddUserAsync(user).ConfigureAwait(false);

            var token = _jwtProvider.GenerateToken(user);

            return new UserRegisterResponse
            {
                IsSuccess = true,
                Message = "User registered successfully",
                Token = token,
                UserName = user.Username
            };            
        }

        public async Task<UserLoginResponse> LoginAsync(UserLoginDto loginDto)
        {
            User user = await _userRepository.GetUserByEmailAsync(loginDto.Email).ConfigureAwait(false);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            var passwordVerified = _passwordHasher.Verify(loginDto.Password, user.PasswordHash);

            if (!passwordVerified)
            {
                throw new CredentialsFailedException();
            }

            var token = _jwtProvider.GenerateToken(user);

            return new UserLoginResponse
            {
                IsSuccess = true,
                Message = "User logged in successfully",
                Token = token,
                UserName = user.Username
            };
        }
    }
}
