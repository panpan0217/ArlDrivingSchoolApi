using ArlDrivingSchool.Core.Models.Users;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface IUAuthRepository
    {
        Task CreateAccessAsync(Access access);
    }
}
