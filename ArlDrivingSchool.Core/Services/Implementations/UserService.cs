using ArlDrivingSchool.Core.Models.Users;
using ArlDrivingSchool.Core.DataTransferObject.Response;
using ArlDrivingSchool.Core.Repositories.Implementations;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ArlDrivingSchool.Utility.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using ArlDrivingSchool.Utility.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ArlDrivingSchool.Core.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository { get; set; }
        private AppSettings AppSettings { get; }
        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            UserRepository = userRepository;
            AppSettings = appSettings.Value;
        }

        public async Task<UserAuthentication> AuthenticateUserAsync(string userName, string password)
        {
            var user = await UserRepository.AuthenticateUserAsync(userName, password);

            if (user == null)
                return null;

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

            var stringToken = tokenHandler.WriteToken(token);

            return new UserAuthentication
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserId = user.UserId,
                UserTypeId = user.UserTypeId,
                Token = stringToken
            };
        }
    }
}
