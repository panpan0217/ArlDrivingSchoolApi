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
        Task<IEnumerable<StudentSchedule>> GetStudentScheduleByDateAsync(DateTime date, string schedule, string sessionLocation);
        Task<IEnumerable<ShuttleSchedule>> GetShuttleScheduleByDateAsync(DateTime date, string schedule);

        Task<IEnumerable<PDCStudentDetails>> GetAllPDCStudentWithDetailsAsync();

        Task DeletePDCStudentAsync(int pdcStudentId);
        Task CreatePDCStudentWithDetailsAsync(PDCStudentFullDetailRequestModel requestModel);
    }
}
