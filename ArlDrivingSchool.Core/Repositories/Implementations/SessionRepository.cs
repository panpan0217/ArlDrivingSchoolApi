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

        public async Task<int> CreateSessionOneAsync(int studentId, DateTime sessionDate, string schedule, bool shuttle, string sessionLocation)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertSessionOne]",
                                                                    new
                                                                    {
                                                                        StudentId = studentId,
                                                                        SessionDate = sessionDate,
                                                                        Schedule = schedule,
                                                                        Shuttle = shuttle,
                                                                        SessionLocation = sessionLocation
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return sessionId;
        }

        public async Task<int> CreateSessionTwoAsync(int studentId, DateTime sessionDate, string schedule, bool shuttle, string sessionLocation)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertSessionTwo]",
                                                                    new
                                                                    {
                                                                        StudentId = studentId,
                                                                        SessionDate = sessionDate,
                                                                        Schedule = schedule,
                                                                        Shuttle = shuttle,
                                                                        SessionLocation = sessionLocation
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return sessionId;
        }

        public async Task<int> CreateSessionThreeAsync(int studentId, DateTime sessionDate, string schedule, bool shuttle, string sessionLocation)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertSessionThree]",
                                                                    new
                                                                    {
                                                                        StudentId = studentId,
                                                                        SessionDate = sessionDate,
                                                                        Schedule = schedule,
                                                                        Shuttle = shuttle,
                                                                        SessionLocation = sessionLocation
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return sessionId;
        }

        public async Task<bool> UpdateSessionOneByStudentIdAsync(UpdateSessionRequestModel paymentRequest)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var result = await connection.ExecuteAsync("[sessions].[uspUpdateSessionOneByStudentId]",
                                                    paymentRequest,
                                                    commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> UpdateSessionTwoByStudentIdAsync(UpdateSessionRequestModel paymentRequest)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var result = await connection.ExecuteAsync("[sessions].[uspUpdateSessionTwoByStudentId]",
                                                    paymentRequest,
                                                    commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> UpdateSessionThreeByStudentIdAsync(UpdateSessionRequestModel paymentRequest)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var result = await connection.ExecuteAsync("[sessions].[uspUpdateSessionThreeByStudentId]",
                                                    paymentRequest,
                                                    commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<int> DeleteSessionOneAsync(int studentId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            return await connection.ExecuteAsync("[sessions].[uspDeleteSessionOne]",
                                                new
                                                {
                                                    StudentId = studentId
                                                },
                                                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteSessionTwoAsync(int studentId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            return await connection.ExecuteAsync("[sessions].[uspDeleteSessionTwo]",
                                                new
                                                {
                                                    StudentId = studentId
                                                },
                                                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteSessionThreeAsync(int studentId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            return await connection.ExecuteAsync("[sessions].[uspDeleteSessionThree]",
                                                new
                                                {
                                                    StudentId = studentId
                                                },
                                                commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateSessionOneAttendedByStudentIdAsync(int studentId, bool attended)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var request = new
            {
                StudentId = studentId,
                Attended = attended
            };

            var result = await connection.ExecuteAsync("[sessions].[uspUpdateSessionOneAttendedByStudentId]",
                                                    request,
                                                    commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> UpdateSessionTwoAttendedByStudentIdAsync(int studentId, bool attended)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var request = new
            {
                StudentId = studentId,
                Attended = attended
            };

            var result = await connection.ExecuteAsync("[sessions].[uspUpdateSessionTwoAttendedByStudentId]",
                                                    request,
                                                    commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<bool> UpdateSessionThreeAttendedByStudentIdAsync(int studentId, bool attended)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var request = new
            {
                StudentId = studentId,
                Attended = attended
            };

            var result = await connection.ExecuteAsync("[sessions].[uspUpdateSessionThreeAttendedByStudentId]",
                                                    request,
                                                    commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}
