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
    public class StudentStatusRepository : DapperRepository, IStudentStatusRepository
    {
        public StudentStatusRepository(IConfiguration configuration)
            : base(configuration)
        {
       
        }

        public async Task<IEnumerable<StudentStatus>> GetAllAsync()
        {
            return await QueryAsync<StudentStatus>("lookups.uspGetStudentStatus");
        }
    }
}
