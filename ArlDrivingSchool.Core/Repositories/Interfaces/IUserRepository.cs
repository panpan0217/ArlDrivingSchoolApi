﻿using ArlDrivingSchool.Core.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface IUserRepository 
    {
        Task CreateAsync(User user);
        Task<User> AuthenticateUserAsync(string userName, string password);
        Task<User> GetUserByUserId(int userId);
        Task SaveProfileLinkAync(int userId, string profileLink);
        Task<IEnumerable<User>> GetAllUser();
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(User entity);
        Task CreateLogActivityAsync(ActivityLog activityLog);
    }
}
