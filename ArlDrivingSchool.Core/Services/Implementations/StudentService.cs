using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.DataTransferObject.Response;
using ArlDrivingSchool.Core.Models;
using ArlDrivingSchool.Core.Models.Users;
using ArlDrivingSchool.Core.Repositories.Implementations;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private IStudentRepository StudentRepository { get; }
        private ISessionRepository SessionRepository { get; }
        private IPaymentRepository PaymentRepository { get; }

        public StudentService(IStudentRepository studentRepository, ISessionRepository sessionRepository, IPaymentRepository paymentRepository)
        {
            StudentRepository = studentRepository;
            SessionRepository = sessionRepository;
            PaymentRepository = paymentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await StudentRepository.GetAllAsync();
        }

        public async Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsAsync()
        {
            return await StudentRepository.GetAllStudentWithDetailsAsync();
        }

        public async Task CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel)
        {
            var studentId = await StudentRepository.CreateStudentWithDetailsAsync(new StudentDetailsRequestModel {
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Email = requestModel.Email,
                Location = requestModel.Location,
                FBContact = requestModel.FBContact,
                Mobile = requestModel.Mobile,
                StudentStatusId = requestModel.StudentStatusId,
                TDCStatusId = requestModel.TDCStatusId,
                ACESStatusId = requestModel.ACESStatusId,
                Remarks = requestModel.Remarks,
                Package = requestModel.Package
            });

            await SessionRepository.CreateSessionOneAsync(
                studentId: studentId,
                schedule: requestModel.SessionOneSchedule,
                shuttle: requestModel.SessionOneShuttle,
                sessionLocation: requestModel.SessionOneLocation
                );
         
            await SessionRepository.CreateSessionTwoAsync(
                studentId: studentId,
                schedule: requestModel.SessionTwoSchedule,
                shuttle: requestModel.SessionTwoShuttle,
                sessionLocation: requestModel.SessionTwoLocation
                );
            
            await SessionRepository.CreateSessionThreeAsync(
                studentId: studentId,
                time: requestModel.Time,
                branch: requestModel.Branch
                );

            await PaymentRepository.CreatePaymentAsync(
                studentId,
                totalAmount: requestModel.TotalAmount,
                payment: requestModel.Payment,
                balance: requestModel.Balance
                );
        }
    }
}
