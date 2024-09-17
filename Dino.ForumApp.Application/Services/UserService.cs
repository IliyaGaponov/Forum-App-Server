using AutoMapper;
using Dino.ForumApp.Application.Interfaces;
using Dino.ForumApp.DataAccess.Interfaces;
using Dino.ForumApp.Domain.Models;
using Dino.ForumApp.Application.DTOs;
using Dino.ForumApp.Application.Interfaces.Auth;
using Dino.ForumApp.Domain.Exceptions;

namespace Dino.ForumApp.Application.Services
{
    /// <summary>
    /// Service for managing user-related operations.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="passwordHasher">The password hasher.</param>
        /// <param name="jwtProvider">The jwt provider.</param>
        /// <param name="mapper">The automapper.</param>
        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider, IMapper mapper)
        {
            this._userRepository = userRepository;
            this._passwordHasher = passwordHasher;
            this._jwtProvider = jwtProvider;
            this._mapper = mapper;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="registrationDto">The register data transfer object (DTO) containing user register information.</param>
        /// <returns>Returns the token and username of the newly created user.</returns>
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

        /// <summary>
        /// Logins a user.
        /// </summary>
        /// <param name="loginDto">The login data transfer object (DTO) containing user login information.</param>
        /// <returns>Returns the token and username of the logged in user.</returns>
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
