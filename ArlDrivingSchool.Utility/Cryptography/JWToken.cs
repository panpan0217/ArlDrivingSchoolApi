using ArlDrivingSchool.Utility.DomainModels;
using ArlDrivingSchool.Utility.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ArlDrivingSchool.Utility.Cryptography
{
    public class JWToken
    {
        private AppSettings AppSettings { get; }
        public JWToken(IOptions<AppSettings> appSettings)
        {
            AppSettings = appSettings.Value;
        }

        public string GenerateToken(User user)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.Role, user.UserType),
                    new Claim("Email", user.Email),
                    new Claim("UserId", $"{user.UserId}"),
                    new Claim("UserName", user.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public List<Claim> DecryptToken(StringValues token)
        {
            var accessToken = token.ToString();

            if (accessToken.StartsWith("Bearer "))
            {
                accessToken = accessToken.Substring(7);
            }

            return new JwtSecurityTokenHandler().ReadJwtToken(accessToken).Claims.ToList();
        }

    }
}
