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
    public class TDCStatusRepository : DapperRepository, ITDCStatusRepository
    {
        public TDCStatusRepository(IConfiguration configuration)
            :base(configuration)
        {

        }

        public async Task<IEnumerable<TDCStatus>> GetAllAsync()
        {
            return await QueryAsync<TDCStatus>("lookups.uspGetTDCStatus");
        }
    }
}
