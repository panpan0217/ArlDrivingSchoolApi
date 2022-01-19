using ArlDrivingSchool.Core.Models.Users;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Repositories.ObjectRelationalMapper;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Implementations
{
    public class UAuthRepository : DapperRepository, IUAuthRepository
    {
        public UAuthRepository(IConfiguration configuration)
                    : base(configuration)
        {
        }

        public async Task CreateAccessAsync(Access entity)
        {
            await ExecuteAsync("[users].[uspInsertAccess]", new
            {
                entity.Auth,
                entity.Salt,
                entity.UserId,
                entity.CreatedAt,
                entity.UpdatedAt,
                entity.ExpirationDate,
                entity.IsTempAuthActive,
            });
        }
    }
}
