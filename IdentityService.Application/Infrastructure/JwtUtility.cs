using IdentityService.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Infrastructure
{
    public static class JwtUtility
    {
        static JwtUtility()
        {

        }
        public static string GenerateJwtToken(User user,int expireMinutes)
        {
            byte[] key = System.Text.Encoding.ASCII.GetBytes("behinrahkarbehinrahkhansarihamidjalalat");

            var symmetricSecurityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key: key);

            var securityAlgorithm = Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature;

            var signigCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(key: symmetricSecurityKey, algorithm: securityAlgorithm);

            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { 
                                                     new Claim(nameof(user.FirstName), user.FirstName),
                                                     new Claim(nameof(user.LastName), user.LastName),
                                                     new Claim(ClaimTypes.Name, user.UserName),
                                                     new Claim(ClaimTypes.Email, user.EmailAddress),
                                                     new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),     }),

                Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
                SigningCredentials = signigCredentials
            };
            var tokenHandler =new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            Microsoft.IdentityModel.Tokens.SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor: tokenDescriptor);

            string token = tokenHandler.WriteToken(token:securityToken);

            return token;
        }

    }
}
