
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

        Task<int> CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel, DateTime? acesSaveDate, string createdBy);

        Task<bool> UpdateStudentByStudentIdAsync(Student student, DateTime? acesSaveDate, string updatedBy);

        Task<int> DeleteStudentAsync(int studentId);
        Task<IEnumerable<StudentSchedule>> GetStudentScheduleByDateAsync(DateTime date, string schedule, string sessionLocation, int branchId);
        Task<IEnumerable<ShuttleSchedule>> GetShuttleScheduleByDateAsync(DateTime date, string schedule, int branchId);

        Task<IEnumerable<PDCStudentDetails>> GetAllPDCStudentWithDetailsAsync();
        Task<IEnumerable<PDCStudentDetails>> GetAllPDCStudentWithDetailsByFullNameAsync(string fullName);
        Task<int> DeletePDCStudentAsync(int pdcStudentId);
        Task<int> CreatePDCStudentWithDetailsAsync(PDCStudentFullDetailRequestModel requestModel, string createdBy);
        Task<bool> UpdatePDCStudentByStudentIdAsync(PDCStudent pdcStudent, string updatedBy);
        Task<PDCStudent> GetPDCStudentById(int pDCStudentId);
        Task<IEnumerable<StudentCertification>> GetStudentByParams(int certified, DateTime startDate, DateTime endDate);
        Task<IEnumerable<PDCStudentCertification>> GetPDCStudentByParams(int certified, DateTime startDate, DateTime endDate);
        Task<IEnumerable<DEPStudentCertification>> GetDEPStudentByParams(int certified, DateTime startDate, DateTime endDate);
        Task UpdateStudentCertificationByIdsAsync(string ids);
        Task UpdatePDCStudentCertificationByIdsAsync(string ids);
        Task UpdateDEPStudentCertificationByIdsAsync(string ids);
        Task UpdateUncertifiedStudentByIdAsync(int id);
        Task UpdateUncertifiedPDCStudentByIdAsync(int id);
        Task UpdateUncertifiedDEPStudentByIdAsync(int id);
        Task<IEnumerable<StudentDetails>> GetStudentWithDetailsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<PDCStudentDetails>> GetPDCStudentWithDetailsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<StudentDetails> GetStudentByIdAsync(int studentId);
        Task<PDCStudentDetails> GetPDCStudentWithDetailsByIdAsync(int studentId);

        //DEP
        Task<int> CreateDEPStudentWithDetailsAsync(DEPStudentFullDetailsRequestModel requestModel, string createdBy);
        Task<bool> UpdateDEPStudentWithDetailsAsync(DEPStudentFullDetailsRequestModel requestModel, string createdBy);
        Task<IEnumerable<DEPStudentDetails>> GetAllDEPStudentWithDetailsAsync(DateTime startDate, DateTime endDate);
        Task<DEPStudentDetails> GetDEPStudentByIdAsync(int studentId);
        Task<IEnumerable<DEPStudentSchedule>> GetDEPStudentScheduleByDateAsync(DateTime date, string schedule, string sessionLocation, int branchId);
        Task<IEnumerable<TotalStudentAndCertification>> GetTotalStudentAndCertificationAsync(DateTime startDate, DateTime endDate);
        Task<Student> GetStudentInfoById(int studentId);
        Task<IEnumerable<DEPStudentDetails>> GetAllDEPStudentWithDetailsByFullNameAsync(string fullName);
    }
}
