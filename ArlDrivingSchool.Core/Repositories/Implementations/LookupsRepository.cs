using ArlDrivingSchool.Core.Models.Lookups;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Repositories.ObjectRelationalMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Implementations
{
    public class LookupsRepository : DapperRepository, ILookupsRepository
    {
        private IConfiguration Configuration { get; }

        public LookupsRepository(IConfiguration configuration)
       : base(configuration)
        {
            Configuration = configuration;
        }

        public async Task<IEnumerable<Restriction>> GetAllRestrictionAsync()
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            return await connection.QueryAsync<Restriction>("[lookups].[uspGetRestriction]"
                                                                , commandType: CommandType.StoredProcedure);
          
        }
        
        public async Task<IEnumerable<Transmission>> GetALLTransmissionAsync()
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            return await connection.QueryAsync<Transmission>("[lookups].[uspGetTransmission]"
                                                                , commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<DriveSafeStatus>> GetDriveSafeStatusAsync()
        {
            return await QueryAsync<DriveSafeStatus>("lookups.uspGetDriveSafeStatus");
        }
    }
}
