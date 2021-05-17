using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.DataTransferObject.Response;
using ArlDrivingSchool.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<IEnumerable<PDCSession>> GetPDCSessionByInstructorId(int instructorId);
        Task<IEnumerable<PDCSession>> GetAllPDCSessionAsync();
        Task<int> CreateSessionOneAsync(int studentId, DateTime sessionDate, string schedule, bool shuttle, string sessionLocation, int branchId);
        Task<int> CreateSessionTwoAsync(int studentId, DateTime sessionDate, string schedule, bool shuttle, string sessionLocation, int branchId);
        Task<int> CreateSessionThreeAsync(int studentId, DateTime sessionDate, string schedule, bool shuttle, string sessionLocation, int branchId);
        Task<bool> UpdateSessionOneByStudentIdAsync(UpdateSessionRequestModel paymentRequest);
        Task<bool> UpdateSessionTwoByStudentIdAsync(UpdateSessionRequestModel paymentRequest);
        Task<bool> UpdateSessionThreeByStudentIdAsync(UpdateSessionRequestModel paymentRequest);
        Task<int> DeleteSessionOneAsync(int studentId);
        Task<int> DeleteSessionTwoAsync(int studentId);
        Task<int> DeleteSessionThreeAsync(int studentId);
        Task<bool> UpdateSessionOneAttendedByStudentIdAsync(int studentId, bool attended);
        Task<bool> UpdateSessionTwoAttendedByStudentIdAsync(int studentId, bool attended);
        Task<bool> UpdateSessionThreeAttendedByStudentIdAsync(int studentId, bool attended);
        Task<int> CreatePDCSessionOneAsync(int pDCStudentId, DateTime date, DateTime startTime, DateTime endTime, bool attended);
        Task<int> CreatePDCSessionTwoAsync(int pDCStudentId, DateTime date, DateTime startTime, DateTime endTime, bool attended);
        Task<int> CreatePDCSessionThreeAsync(int pDCStudentId, DateTime date, DateTime startTime, DateTime endTime, bool attended);
        Task<int> CreatePDCSessionFourAsync(int pDCStudentId, DateTime date, DateTime startTime, DateTime endTime, bool attended);
        Task<int> CreatePDCSessionAsync(string pdcStudentId, DateTime date, DateTime startTime, DateTime endTime, int instructorId, bool attended);
        Task UpdatePDCSessionAsync(PDCSessionRequestModel request);
        Task DeletePDCSessionAsync(int pDCSessionId);
    }
}
