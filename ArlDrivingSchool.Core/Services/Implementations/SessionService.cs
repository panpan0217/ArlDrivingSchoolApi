using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
