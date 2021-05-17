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
using ArlDrivingSchool.Core.DataTransferObject.Response;

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

        public async Task<IEnumerable<PDCSession>> GetPDCSessionByInstructorId(int instructorId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var parameter = new
            {
                Id = instructorId
            };

            var pDCSessions = await connection.QueryAsync<PDCSession>(
                   "[sessions].[uspGetPDCSessionByInstructorId]",
                   param: parameter,
                   commandType: CommandType.StoredProcedure
               );

            return pDCSessions;
        }

        public async Task<IEnumerable<PDCSession>> GetAllPDCSessionAsync()
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var pDCSessions = await connection.QueryAsync<PDCSession>("[sessions].[uspGetPDCSession]"
                                                                , commandType: CommandType.StoredProcedure);
            return pDCSessions;
        }

        public async Task<int> CreateSessionOneAsync(int studentId, DateTime sessionDate, string schedule, bool shuttle, 
            string sessionLocation, int branchId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertSessionOne]",
                                                                    new
                                                                    {
                                                                        StudentId = studentId,
                                                                        SessionDate = sessionDate,
                                                                        Schedule = schedule,
                                                                        Shuttle = shuttle,
                                                                        SessionLocation = sessionLocation,
                                                                        BranchId = branchId
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return sessionId;
        }

        public async Task<int> CreateSessionTwoAsync(int studentId, DateTime sessionDate, string schedule, bool shuttle, 
            string sessionLocation, int branchId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertSessionTwo]",
                                                                    new
                                                                    {
                                                                        StudentId = studentId,
                                                                        SessionDate = sessionDate,
                                                                        Schedule = schedule,
                                                                        Shuttle = shuttle,
                                                                        SessionLocation = sessionLocation,
                                                                        BranchId = branchId
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return sessionId;
        }

        public async Task<int> CreateSessionThreeAsync(int studentId, DateTime sessionDate, string schedule, bool shuttle, 
            string sessionLocation, int branchId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertSessionThree]",
                                                                    new
                                                                    {
                                                                        StudentId = studentId,
                                                                        SessionDate = sessionDate,
                                                                        Schedule = schedule,
                                                                        Shuttle = shuttle,
                                                                        SessionLocation = sessionLocation,
                                                                        BranchId = branchId
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

        public async Task<int> CreatePDCSessionAsync(string pdcStudentId, DateTime date, DateTime startTime, DateTime endTime, int instructorId, bool attended)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertPDCSession]",
                                                                    new
                                                                    {
                                                                        PDCStudentId = pdcStudentId,
                                                                        Date = date,
                                                                        StartTime = startTime,
                                                                        EndTime = endTime,
                                                                        InstructorId = instructorId,
                                                                        Attended = attended
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return sessionId;
        }

        public async Task UpdatePDCSessionAsync(PDCSessionRequestModel request)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var result = await connection.ExecuteAsync("[sessions].[uspUpdatePDCSession]",
                                                    new 
                                                    {
                                                        PDCSessionId = request.PDCSessionId,
                                                        PDCStudentId = request.PDCStudentId,
                                                        Date = request.Date,
                                                        StartTime = request.StartTime,
                                                        EndTime = request.EndTime,
                                                        InstructorId = request.InstructorId,
                                                        Attended = request.Attended
                                                    },
                                                    commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CreatePDCSessionOneAsync(int pDCStudentId, DateTime date, DateTime startTime, DateTime endTime, bool attended)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertPDCSessionOne]",
                                                                    new
                                                                    {
                                                                        PDCStudentId = pDCStudentId,
                                                                        Date = date,
                                                                        StartTime = startTime,
                                                                        EndTime = endTime,
                                                                        Attended = attended
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return sessionId;
        }

        public async Task<int> CreatePDCSessionTwoAsync(int pDCStudentId, DateTime date, DateTime startTime, DateTime endTime, bool attended)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertPDCSessionTwo]",
                                                                    new
                                                                    {
                                                                        PDCStudentId = pDCStudentId,
                                                                        Date = date,
                                                                        StartTime = startTime,
                                                                        EndTime = endTime,
                                                                        Attended = attended
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return sessionId;
        }

        public async Task<int> CreatePDCSessionThreeAsync(int pDCStudentId, DateTime date, DateTime startTime, DateTime endTime, bool attended)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertPDCSessionThree]",
                                                                    new
                                                                    {
                                                                        PDCStudentId = pDCStudentId,
                                                                        Date = date,
                                                                        StartTime = startTime,
                                                                        EndTime = endTime,
                                                                        Attended = attended
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return sessionId;
        }

        public async Task<int> CreatePDCSessionFourAsync(int pDCStudentId, DateTime date, DateTime startTime, DateTime endTime, bool attended)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var sessionId = await connection.ExecuteScalarAsync<int>("[sessions].[uspInsertPDCSessionFour]",
                                                                    new
                                                                    {
                                                                        PDCStudentId = pDCStudentId,
                                                                        Date = date,
                                                                        StartTime = startTime,
                                                                        EndTime = endTime,
                                                                        Attended = attended
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return sessionId;
        }

        public async Task DeletePDCSessionAsync(int pDCSessionId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            await connection.ExecuteAsync("[sessions].[uspDeletePDCSession]",
                                                new
                                                {
                                                    PDCSessionId = pDCSessionId
                                                },
                                                commandType: CommandType.StoredProcedure);
        }
    }
}
