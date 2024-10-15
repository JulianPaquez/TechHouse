using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly AuthenticationServiceOptions _options;

        public AuthService(IUserRepository userRepository, IOptions<AuthenticationServiceOptions> options)
        {
            _userRepository = userRepository;
            _options = options.Value;
        }

        public User? ValidateCredentials(CredentialsForAuthenticate credentials)
        {
            if (string.IsNullOrEmpty(credentials.UserName) || string.IsNullOrEmpty(credentials.Password))
                return null;

            var user = _userRepository.GetByUsername(credentials.UserName);

            if (user == null) return null;

            if (credentials.Password == user.Password)
            {
                return user;
            }
            return null;
        }

        public string Authenticate(CredentialsForAuthenticate credentials)
        {
            var user = ValidateCredentials(credentials);

            //Falta validar excepcion para que no responda un 204.
            if (user == null)
            {
                return null;
            }
            

            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.SecretForKey));
            var data = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>
    {
        new Claim("sub", user.Id.ToString()),
        new Claim("given_name", user.Name),
        new Claim("family_name", user.LastName)
    };

            var jwtSecurityToken = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                data
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        public class AuthenticationServiceOptions
        {
            public const string AuthService = "AuthService";

            //Agregue string.Empty para advertencias
            public string Issuer { get; set; } = string.Empty;
            public string Audience { get; set; } = string.Empty;
            public string SecretForKey { get; set; } = string.Empty;
        }


    }
}