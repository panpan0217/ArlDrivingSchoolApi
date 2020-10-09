using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<int> CreateSessionOneAsync(int studentId, DateTime sessionDate, string schedule, bool shuttle, string sessionLocation);
        Task<int> CreateSessionTwoAsync(int studentId, DateTime sessionDate, string schedule, bool shuttle, string sessionLocation);
        Task<int> CreateSessionThreeAsync(int studentId, DateTime sessionDate, string schedule, bool shuttle, string sessionLocation);
        Task<bool> UpdateSessionOneByStudentIdAsync(UpdateSessionRequestModel paymentRequest);
        Task<bool> UpdateSessionTwoByStudentIdAsync(UpdateSessionRequestModel paymentRequest);
        Task<bool> UpdateSessionThreeByStudentIdAsync(UpdateSessionRequestModel paymentRequest);
    }
}
