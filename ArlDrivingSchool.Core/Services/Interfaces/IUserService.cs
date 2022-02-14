using ArlDrivingSchool.Core.DataTransferObject.Response;
using ArlDrivingSchool.Core.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserAuthentication> AuthenticateUserAsync(string userName, string password);
        Task SaveProfileLinkAync(int userId, string profileLink);
        Task CreateAsync(User entity, string password);
        Task<IEnumerable<User>> GetAllUser();
        Task DeleteByIdAsync(int id);
        Task UpdateAsync(User entity);
        Task UpdatePasswordAsync(User entity, string password);
        Task<User> GetByIdAsync(int userId);
        Task CreateLogActivityAsync(ActivityLog activityLog);
    }
}
