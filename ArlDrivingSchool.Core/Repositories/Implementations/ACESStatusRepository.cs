using ArlDrivingSchool.Core.Models.Lookups;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Repositories.ObjectRelationalMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Implementations
{
    public class ACESStatusRepository : DapperRepository, IACESStatusRepository
    {
        public ACESStatusRepository(IConfiguration configuration)
            :base(configuration)
        {

        }

        public async Task<IEnumerable<ACESStatus>> GetAllAsync()
        {
            return await QueryAsync<ACESStatus>("lookups.uspGetACESStatus");
        }
    }
}
