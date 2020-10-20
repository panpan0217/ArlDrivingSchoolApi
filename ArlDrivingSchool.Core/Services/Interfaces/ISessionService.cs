using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Interfaces
{
    public interface ISessionService
    {
        Task<bool> UpdateSessionOneAttendedByStudentIdAsync(int studentId, bool attended);
        Task<bool> UpdateSessionTwoAttendedByStudentIdAsync(int studentId, bool attended);
        Task<bool> UpdateSessionThreeAttendedByStudentIdAsync(int studentId, bool attended);
    }
}
