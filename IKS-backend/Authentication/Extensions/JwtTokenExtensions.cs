using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using My_IKS.Data.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace My_IKS.Authentication.Extensions
{
    public static class JwtTokenExtensions
    {

        public static string GenerateJwtToken(this User user, IList<string> roles, string secret)
        {
            IdentityOptions options = new IdentityOptions();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim(options.ClaimsIdentity.RoleClaimType, roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }
    }
}
