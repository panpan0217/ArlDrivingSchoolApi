using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Implementations
{
    public class SessionService : ISessionService
    {
        private IStudentRepository StudentRepository { get; }
        private IPaymentRepository PaymentRepository { get; }
        private ISessionRepository SessionRepository { get; }

        public SessionService(IStudentRepository studentRepository, IPaymentRepository paymentRepository, ISessionRepository sessionRepository)
        {
            StudentRepository = studentRepository;
            PaymentRepository = paymentRepository;
            SessionRepository = sessionRepository;
        }

        public async Task<bool> UpdateSessionOneAttendedByStudentIdAsync(int studentId, bool attended)
        {
            return await SessionRepository.UpdateSessionOneAttendedByStudentIdAsync(studentId, attended);
        }

        public async Task<bool> UpdateSessionTwoAttendedByStudentIdAsync(int studentId, bool attended)
        {
            return await SessionRepository.UpdateSessionTwoAttendedByStudentIdAsync(studentId, attended);
        }

        public async Task<bool> UpdateSessionThreeAttendedByStudentIdAsync(int studentId, bool attended)
        {
            return await SessionRepository.UpdateSessionThreeAttendedByStudentIdAsync(studentId, attended);
        }
    }
}
