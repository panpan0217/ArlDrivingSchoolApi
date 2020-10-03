using ArlDrivingSchool.Core.Models.Lookups;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Implementations
{
    public class StudentStatusService : IStudentStatusService
    {
        private IStudentStatusRepository StudentStatusRepository { get; set; }
        public StudentStatusService(IStudentStatusRepository studentStatusRepository)
        {
            StudentStatusRepository = studentStatusRepository;
        }
        public async Task<IEnumerable<StudentStatus>> GetAllAsync()
        {
            return await StudentStatusRepository.GetAllAsync();
        }
    }
}
