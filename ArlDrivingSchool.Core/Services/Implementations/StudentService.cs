using ArlDrivingSchool.Core.DataTransferObject.Response;
using ArlDrivingSchool.Core.Models;
using ArlDrivingSchool.Core.Models.Users;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private IStudentRepository StudentRepository { get; }

        public StudentService(IStudentRepository studentRepository)
        {
            StudentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await StudentRepository.GetAllAsync();
        }

        public async Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsAsync()
        {
            return await StudentRepository.GetAllStudentWithDetailsAsync();
        }
    }
}
