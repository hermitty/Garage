using Garage.Domain.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper.Configuration;
using Garage.Infrastructure.Helpers;
using Microsoft.Extensions.Options;

namespace Garage.Infrastructure.Service
{
    public class IdentityService : IIdentityService
    {
        private readonly AppSettings appSettings;

        public IdentityService(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }
        public string GenerateTokenForUser(int userId, string userRole)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId.ToString()),
                    new Claim(ClaimTypes.Role, userRole)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
