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
        Task<PDCStudent> GetPDCStudentByIdAsync(int pDCStudentId);
        Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsAsync();
        Task<IEnumerable<StudentDetails>> GetStudentWithDetailsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel, int userId);
        Task<bool> UpdateStudentByStudentIdAsync(UpdateStudentDetailsRequestModel student, int userId);
        Task DeleteStudentAsync(int studentId);
        Task<IEnumerable<StudentSchedule>> GetStudentScheduleByDateAsync(DateTime date, string schedule, string sessionLocation);
        Task<IEnumerable<ShuttleSchedule>> GetShuttleScheduleByDateAsync(DateTime date, string schedule);

        Task<IEnumerable<PDCStudentDetails>> GetAllPDCStudentWithDetailsAsync();

        Task DeletePDCStudentAsync(int pdcStudentId);
        Task CreatePDCStudentWithDetailsAsync(PDCStudentFullDetailRequestModel requestModel, int userId);
        Task<bool> UpdatePDCStudentByStudentIdAsync(PDCStudentFullDetailRequestModel requestModel, int userId);
        Task<IEnumerable<StudentCertification>> GetStudentByParams(int certified);
        Task<IEnumerable<PDCStudentCertification>> GetPDCStudentByParams(int certified);
        Task UpdateStudentCertificationByIdsAsync(string ids);
        Task UpdatePDCStudentCertificationByIdsAsync(string ids);
        Task UpdateUncertifiedStudentByIdAsync(int id);
        Task UpdateUncertifiedPDCStudentByIdAsync(int id);
    }
}
