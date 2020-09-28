using ArlDrivingSchool.Core.Models;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Repositories.ObjectRelationalMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using ArlDrivingSchool.Core.DataTransferObject.Request;

namespace ArlDrivingSchool.Core.Repositories.Implementations
{
    public class SessionRepository : DapperRepository, ISessionRepository
    {
        private IConfiguration Configuration { get; }

        public SessionRepository(IConfiguration configuration)
            : base(configuration)
        {
            Configuration = configuration;
        }

        public async Task<int> CreateSessionOneAsync(int studentId, string schedule, bool shuttle, string sessionLocation)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertSessionOne]",
                                                                    new
                                                                    {
                                                                        StudentId = studentId,
                                                                        Schedule = schedule,
                                                                        Shuttle = shuttle,
                                                                        SessionLocation = sessionLocation
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return sessionId;
        }

        public async Task<int> CreateSessionTwoAsync(int studentId, string schedule, bool shuttle, string sessionLocation)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertSessionTwo]",
                                                                    new
                                                                    {
                                                                        StudentId = studentId,
                                                                        Schedule = schedule,
                                                                        Shuttle = shuttle,
                                                                        SessionLocation = sessionLocation
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return sessionId;
        }

        public async Task<int> CreateSessionThreeAsync(int studentId, string branch)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertSessionThree]",
                                                                    new
                                                                    {
                                                                        StudentId = studentId,
                                                                        Branch = branch,
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return sessionId;
        }
    }
}
