using ArlDrivingSchool.Core.DataTransferObject.Response;
using ArlDrivingSchool.Core.Models.Users;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using ArlDrivingSchool.Utility.Cryptography;
using ArlDrivingSchool.Utility.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository { get; set; }
        private AppSettings AppSettings { get; }
        private IUAuthRepository UAuthRepository { get; }
        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings,
            IUAuthRepository uAuthRepository)
        {
            UserRepository = userRepository;
            AppSettings = appSettings.Value;
            UAuthRepository = uAuthRepository;
        }


        public async Task CreateAsync(User entity, string password)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            await UserRepository.CreateAsync(entity);

            await CreatePasswordAsync(entity, password);
        }

        private async Task CreatePasswordAsync(User user, string password)
        {
            if (user.UserId < 0)
                return;

            var salt = Salt.Create();

            var auth = Hash.Create(password, salt);

            var uAuth = new Access
            {
                UserId = user.UserId,
                Auth = auth,
                Salt = salt,
                IsTempAuthActive = false,
                ExpirationDate = DateTime.UtcNow.AddYears(100),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await UAuthRepository.CreateAccessAsync(uAuth);
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
                    new Claim("UserName", user.Username),
                    new Claim("ProfileLink", user.ProfileLink != null ? user.ProfileLink : "")
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

        public async Task SaveProfileLinkAync(int userId, string profileLink)
        {
            await UserRepository.SaveProfileLinkAync(userId, profileLink);
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await UserRepository.GetAllUser();
        }
    }
}
