using InvoiceSystemAPI.Configuration;
using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Services.Abstracts;
using InvoiceSystemAPI.Tools.Abstracts;
using Microsoft.IdentityModel.SecurityTokenService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InvoiceSystemAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly AuthenticationConfiguration _authenticationConfiguration;

        public AuthService(AuthenticationConfiguration authenticationConfiguration,
            IPasswordHasher passwordHasher)
        {
            _authenticationConfiguration = authenticationConfiguration;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> GenerateTokenAsync(User user, string password)
        {
            if (!_passwordHasher.Compare(password, user.Password, user.Salt))
            {
                throw new BadRequestException("Invalid user login or password");
            }

            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Name} {user.Surname}")
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationConfiguration.JwtKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expires = DateTime.Now.AddDays(_authenticationConfiguration.JwtExpireDays);

            JwtSecurityToken token = new JwtSecurityToken(_authenticationConfiguration.JwtIssuer,
                _authenticationConfiguration.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: credentials);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
