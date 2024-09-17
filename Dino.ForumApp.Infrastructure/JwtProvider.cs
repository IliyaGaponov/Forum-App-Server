using Dino.ForumApp.Application.Interfaces.Auth;
using Dino.ForumApp.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Dino.ForumApp.Infrastructure
{
    /// <summary>
    /// Provides functionality for generating and validating JWT tokens.
    /// </summary>
    public class JwtProvider : IJwtProvider
    {
        /// <summary>
        /// Generates a JWT token for the specified user.
        /// </summary>
        /// <param name="user">The auth user.</param>
        /// <returns>Returns a JWT token string.</returns>
        public string GenerateToken(User user)
        {
            Claim[] claims = [new("userId", user.Id.ToString())];
            var token = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromHours(1)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
