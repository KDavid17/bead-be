using BeadBE.Application.Common.Interfaces.Authentication;
using BeadBE.Application.Common.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BeadBE.Infrastructure.Authentication
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtSettings _jwtSettings;

        public JwtGenerator(IConfiguration configuration, IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions)
        {
            _configuration = configuration;
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(string email)
        {
            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, email)
            };

            SymmetricSecurityKey key = new(System.Text.Encoding.UTF8.GetBytes(_jwtSettings.Secret));

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken token = new(
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                issuer: _jwtSettings.Issuer,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
