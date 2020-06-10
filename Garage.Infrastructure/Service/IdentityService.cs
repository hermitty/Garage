using Garage.Domain.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Garage.Infrastructure.Service
{
    public class IdentityService : IIdentityService
    {
        private object user;

        public string GenerateTokenForUser(int userId, string userRole)
        {
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, userId.ToString()),
            //        new Claim(ClaimTypes.Role, userRole)
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //return tokenHandler.WriteToken(token);
            var claims = new List<Claim>
                 {
                     new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                     new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole)
                };

          

            // get options
           // var jwtAppSettingOptions = _configuration.GetSection("JwtIssuerOptions");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(8);

            var token = new JwtSecurityToken(
           null, null,
                claims,
                expires: expires,
                signingCredentials: creds
            ); ;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
