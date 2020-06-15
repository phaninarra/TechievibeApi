using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Techievibe.Api.Authentication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private string _authKey;
        public JwtAuthenticationManager(string authKey)
        {
            _authKey = authKey;
        }
        private readonly IDictionary<string, string> authorizedUsers = new Dictionary<string, string>
        {
            { "techievibeui", "fZ27f1CeG!Rd" }
        };
        public string Authenticate(string username, string password)
        {
            if (!authorizedUsers.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_authKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);


            var tokenString = tokenHandler.WriteToken(token);

            return tokenString ?? "Hello Guru";
        }
    }
}
