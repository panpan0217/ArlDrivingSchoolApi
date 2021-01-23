using ArlDrivingSchool.Core.DataTransferObject.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Interfaces
{
    public interface ISessionService
    {
        Task<IEnumerable<PDCSession>> GetAllPDCSessionAsync();
        Task<bool> UpdateSessionOneAttendedByStudentIdAsync(int studentId, bool attended);
        Task<bool> UpdateSessionTwoAttendedByStudentIdAsync(int studentId, bool attended);
        Task<bool> UpdateSessionThreeAttendedByStudentIdAsync(int studentId, bool attended);
        Task<IEnumerable<PDCSession>> GetAllPDCSessionByInstructorIdAsync(int instructorId);
    }
}
