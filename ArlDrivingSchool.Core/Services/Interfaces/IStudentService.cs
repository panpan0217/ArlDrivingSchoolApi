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
        Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsByFullNameAsync(string firstName, string lastName);
        Task<IEnumerable<StudentDetails>> GetStudentWithDetailsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<PDCStudentDetails>> GetPDCStudentWithDetailsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<PdcTdcPaymentDetail> GetTdcPdcPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<int> CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel, int userId);
        Task<bool> UpdateStudentByStudentIdAsync(UpdateStudentDetailsRequestModel student, int userId);
        Task DeleteStudentAsync(int studentId);
        Task<IEnumerable<StudentSchedule>> GetStudentScheduleByDateAsync(DateTime date, string schedule, string sessionLocation, int branchId);
        Task<IEnumerable<ShuttleSchedule>> GetShuttleScheduleByDateAsync(DateTime date, string schedule, int branchId);

        Task<IEnumerable<PDCStudentDetails>> GetAllPDCStudentWithDetailsAsync();
        Task<IEnumerable<PDCStudentDetails>> GetAllPDCStudentWithDetailsByFullNameAsync(string fullName);

        Task DeletePDCStudentAsync(int pdcStudentId);
        Task CreatePDCStudentWithDetailsAsync(PDCStudentFullDetailRequestModel requestModel, int userId);
        Task<bool> UpdatePDCStudentByStudentIdAsync(PDCStudentFullDetailRequestModel requestModel, int userId);
        Task<IEnumerable<StudentCertification>> GetStudentByParams(int certified, DateTime startDate, DateTime endDate);
        Task<IEnumerable<PDCStudentCertification>> GetPDCStudentByParams(int certified, DateTime startDate, DateTime endDate);
        Task<IEnumerable<DEPStudentCertification>> GetDEPStudentByParams(int certified, DateTime startDate, DateTime endDate);
        Task UpdateStudentCertificationByIdsAsync(string ids);
        Task UpdatePDCStudentCertificationByIdsAsync(string ids);
        Task UpdateDEPStudentCertificationByIdsAsync(string ids);
        Task UpdateUncertifiedStudentByIdAsync(int id);
        Task UpdateUncertifiedPDCStudentByIdAsync(int id);
        Task UpdateUncertifiedDEPStudentByIdAsync(int id);
        Task<StudentDetails> GetStudentByIdAsync(int studentId);
        Task<PDCStudentDetails> GetPDCStudentWithDetailsByIdAsync(int studentId);

        //DEP
        Task CreateDEPStudentWithDetailsAsync(DEPStudentFullDetailsRequestModel requestModel, int userId);
        Task<bool> UpdateStudentByStudentIdAsync(DEPStudentFullDetailsRequestModel requestModel, int userId);
        Task<IEnumerable<DEPStudentDetails>> GetAllDEPStudentWithDetailsAsync(DateTime startDate, DateTime endDate);
        Task<DEPStudentDetails> GetDEPStudentByIdAsync(int studentId);
        Task<IEnumerable<DEPStudentSchedule>> GetDEPStudentScheduleByDateAsync(DateTime date, string schedule, string sessionLocation, int branchId);
        Task<IEnumerable<TotalStudentAndCertification>> GetTotalStudentAndCertificationAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<DEPStudentDetails>> GetAllDEPStudentWithDetailsByFullNameAsync(string fullName);
    }
}
