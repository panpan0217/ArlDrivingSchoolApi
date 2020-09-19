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

namespace ArlDrivingSchool.Core.Repositories.Implementations
{
    public class StudentRepository : DapperRepository, IStudentRepository
    {
        private IConfiguration Configuration { get; }

        public StudentRepository(IConfiguration configuration)
            : base(configuration)
        {
            Configuration = configuration;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var students = await connection.QueryAsync<Student>("users.uspGetAllStudent"
                                                                , commandType: CommandType.StoredProcedure);
            return students;
        }
    }
}
