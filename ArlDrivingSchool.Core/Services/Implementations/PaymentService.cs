using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private IStudentRepository StudentRepository { get; }
        private IPaymentRepository PaymentRepository { get; }

        public PaymentService(IStudentRepository studentRepository, IPaymentRepository paymentRepository)
        {
            StudentRepository = studentRepository;
            PaymentRepository = paymentRepository;
        }

    }
}
