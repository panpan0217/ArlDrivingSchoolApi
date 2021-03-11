using ArlDrivingSchool.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AuthenticateUserAsync(string userName, string password);
        Task<User> GetUserByUserId(int userId);
    }
}
