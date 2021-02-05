using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.DataTransferObject.Response;
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

        public async Task<IEnumerable<PDCSession>> GetAllPDCSessionAsync()
        {
            return await SessionRepository.GetAllPDCSessionAsync();
        }

        public async Task<IEnumerable<PDCSession>> GetAllPDCSessionByInstructorIdAsync(int instructorId)
        {
            return await SessionRepository.GetPDCSessionByInstructorId(instructorId);
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

        public async Task<int> CreatePDCSession(int pdcStudentId, DateTime date, DateTime startTime, DateTime endTime, int instructorId, bool attended)
        {
            return await SessionRepository.CreatePDCSessionAsync(pdcStudentId, date, startTime, endTime, instructorId, attended);
        }

        public async Task UpdatePDCSession(PDCSessionRequestModel requestModel)
        {
            await SessionRepository.UpdatePDCSessionAsync(requestModel);
        }

        public async Task DeletePDCSession(int pDCSessionId)
        {
            await SessionRepository.DeletePDCSessionAsync(pDCSessionId);
        }
    }
}
