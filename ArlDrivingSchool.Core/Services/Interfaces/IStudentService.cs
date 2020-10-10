using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.DataTransferObject.Response;
using ArlDrivingSchool.Core.Models;
using ArlDrivingSchool.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsAsync();

        Task CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel);
        Task<bool> UpdateStudentByStudentIdAsync(UpdateStudentDetailsRequestModel student);
        Task DeleteStudentAsync(int studentId);
    }
}
