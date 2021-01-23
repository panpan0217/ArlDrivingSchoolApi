using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.Models.Users;
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
    public class InstructorRepository: DapperRepository, IInstructorRepository
    {
        private IConfiguration Configuration { get; }

        public InstructorRepository(IConfiguration configuration)
       : base(configuration)
        {
            Configuration = configuration;
        }

        public async Task<Instructor> GetInstructorById(int instructorId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var parameter = new
            {
                Id = instructorId
            };

            var instructor = await connection.QuerySingleAsync<Instructor>(
                   "[users].[uspGetInstructorById]",
                   param: parameter,
                   commandType: CommandType.StoredProcedure
               );

            return instructor;
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorAsync()
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            return await connection.QueryAsync<Instructor>("[users].[uspGetInstructor]"
                                                                , commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateInstructorByIdAsync(UpdateInstructorRequestModel instructor)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var result = await connection.ExecuteAsync("[users].[uspUpdateInstructor]",
                                                    instructor,
                                                    commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<int> CreateInstructorAsync(Instructor instructor)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var InstructorId = await connection.ExecuteScalarAsync<int>("[users].[uspInsertInstructor]",
                                                                    new
                                                                    {
                                                                        FullName = instructor.FullName,
                                                                        Status = instructor.Status,
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return InstructorId;
        }

        public async Task<int> DeleteInstructorByIdAsync(int instructorId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            return await connection.ExecuteAsync("[users].[uspDeleteInstructorById]",
                                                new
                                                {
                                                    InstructorId = instructorId
                                                },
                                                commandType: CommandType.StoredProcedure);
        }
    }

}
