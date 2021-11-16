
using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.DataTransferObject.Response;
using ArlDrivingSchool.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsAsync();
        Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsByFullNameAsync(string firstName, string lastName);

        Task<int> CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel, string createdBy);

        Task<bool> UpdateStudentByStudentIdAsync(Student student, string updatedBy);

        Task<int> DeleteStudentAsync(int studentId);
        Task<IEnumerable<StudentSchedule>> GetStudentScheduleByDateAsync(DateTime date, string schedule, string sessionLocation, int branchId);
        Task<IEnumerable<ShuttleSchedule>> GetShuttleScheduleByDateAsync(DateTime date, string schedule, int branchId);

        Task<IEnumerable<PDCStudentDetails>> GetAllPDCStudentWithDetailsAsync();
        Task<IEnumerable<PDCStudentDetails>> GetAllPDCStudentWithDetailsByFullNameAsync(string fullName);
        Task<int> DeletePDCStudentAsync(int pdcStudentId);
        Task<int> CreatePDCStudentWithDetailsAsync(PDCStudentFullDetailRequestModel requestModel, string createdBy);
        Task<bool> UpdatePDCStudentByStudentIdAsync(PDCStudent pdcStudent, string updatedBy);
        Task<PDCStudent> GetPDCStudentById(int pDCStudentId);
        Task<IEnumerable<StudentCertification>> GetStudentByParams(int certified);
        Task<IEnumerable<PDCStudentCertification>> GetPDCStudentByParams(int certified);
        Task UpdateStudentCertificationByIdsAsync(string ids);
        Task UpdatePDCStudentCertificationByIdsAsync(string ids);
        Task UpdateUncertifiedStudentByIdAsync(int id);
        Task UpdateUncertifiedPDCStudentByIdAsync(int id);
        Task<IEnumerable<StudentDetails>> GetStudentWithDetailsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<StudentDetails> GetStudentByIdAsync(int studentId);

        //DEP
        Task<int> CreateDEPStudentWithDetailsAsync(DEPStudentFullDetailsRequestModel requestModel, string createdBy);
        Task<IEnumerable<DEPStudentDetails>> GetAllDEPStudentWithDetailsAsync(DateTime startDate, DateTime endDate);
    }
}
