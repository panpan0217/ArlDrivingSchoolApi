using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ArlDrivingSchool.Core.Models.Users;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Repositories.ObjectRelationalMapper;
using ArlDrivingSchool.Utility.Cryptography;
using Microsoft.Extensions.Configuration;

namespace ArlDrivingSchool.Core.Repositories.Implementations
{
    public class UserRepository : DapperRepository, IUserRepository
    {
        public UserRepository(IConfiguration configuration)
                 : base(configuration)
        {
        }

        public async Task<User> AuthenticateUserAsync(string userName, string password)
        {
            var user = await QueryFirstOrDefaultAsync<User>("[users].[uspGetUserByUsername]",
                new { Username = userName });

            if (user == null)
                return user;

            var access = await QueryFirstOrDefaultAsync<Access>("[users].[uspGetAccessByUserId]",
                new { UserId = user.UserId});

            if (access.Auth == Hash.Create(password, access.Salt))
                return user;
            else
                return null;
                
        }

        public async Task CreateAsync(User entity)
        {
            await ExecuteAsync("[users].[uspInsertUser]", new
            {
                entity.FirstName,
                entity.LastName,
                entity.Username,
                entity.Email,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.UserTypeId,
                entity.Address,
                entity.Birthday
            });

            var user = await QueryFirstOrDefaultAsync<User>("[users].[uspGetUserByUsername]", new
            {
                entity.Username,
            });

            entity.UserId = user.UserId;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await QueryAsync<User>("[users].[uspGetAllUser]");
        }

        public async Task<User> GetUserByUserId(int userId)
        {
            return await QueryFirstOrDefaultAsync<User>("[users].[uspGetUserByUserId]", new
            {
                UserId = userId,
            });
        }

        public async Task SaveProfileLinkAync(int userId, string profileLink)
        {
            await ExecuteAsync("[users].[uspSaveProfileLink]", new
            {
                UserId = userId,
                ProfileLink = profileLink
            });
        }
    }
}
