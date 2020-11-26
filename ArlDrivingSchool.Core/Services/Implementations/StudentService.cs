using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.DataTransferObject.Response;
using ArlDrivingSchool.Core.Models;
using ArlDrivingSchool.Core.Models.Sessions;
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
            var studentId = await StudentRepository.CreateStudentWithDetailsAsync(new StudentFullDetailsRequestModel {
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Email = requestModel.Email,
                Location = requestModel.Location,
                FBContact = requestModel.FBContact,
                Mobile = requestModel.Mobile,
                StudentStatusId = requestModel.StudentStatusId,
                TDCStatusId = requestModel.TDCStatusId,
                ACESStatusId = requestModel.ACESStatusId,
                Remarks = requestModel.Remarks
            });

            await SessionRepository.CreateSessionOneAsync(
                studentId: studentId,
                sessionDate: requestModel.SessionOneDate,
                schedule: requestModel.SessionOneSchedule,
                shuttle: requestModel.SessionOneShuttle,
                sessionLocation: requestModel.SessionOneLocation
                );
         
            await SessionRepository.CreateSessionTwoAsync(
                studentId: studentId,
                sessionDate: requestModel.SessionTwoDate,
                schedule: requestModel.SessionTwoSchedule,
                shuttle: requestModel.SessionTwoShuttle,
                sessionLocation: requestModel.SessionTwoLocation
                );
            
            await SessionRepository.CreateSessionThreeAsync(
                studentId: studentId,
                sessionDate: requestModel.SessionThreeDate,
                schedule: requestModel.SessionThreeSchedule,
                shuttle: requestModel.SessionThreeShuttle,
                sessionLocation: requestModel.SessionThreeLocation
                );

            await PaymentRepository.CreatePaymentAsync(
                studentId,
                totalAmount: requestModel.TotalAmount,
                payment: requestModel.Payment,
                balance: requestModel.Balance
                );
        }

        public async Task<bool> UpdateStudentByStudentIdAsync(UpdateStudentDetailsRequestModel request)
        {
            var student = new Student
            {
                StudentId = request.StudentId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Location = request.Location,
                FBContact = request.FBContact,
                Mobile = request.Mobile,
                StudentStatusId = request.StudentStatusId,
                TDCStatusId = request.TDCStatusId,
                ACESStatusId = request.ACESStatusId,
                Remarks = request.Remarks,
                DateRegistered = request.DateRegistered
            };

            var sessionOne = new UpdateSessionRequestModel
            {
                StudentId = request.StudentId,
                SessionDate = request.SessionOneDate,
                Schedule = request.SessionOneSchedule,
                SessionLocation = request.SessionOneLocation,
                Shuttle = request.SessionOneShuttle
            };

            var sessionTwo = new UpdateSessionRequestModel
            {
                StudentId = request.StudentId,
                SessionDate = request.SessionTwoDate,
                Schedule = request.SessionTwoSchedule,
                SessionLocation = request.SessionTwoLocation,
                Shuttle = request.SessionTwoShuttle
            };

            var sessionThree = new UpdateSessionRequestModel
            {
                StudentId = request.StudentId,
                SessionDate = request.SessionThreeDate,
                Schedule = request.SessionThreeSchedule,
                SessionLocation = request.SessionThreeLocation,
                Shuttle = request.SessionThreeShuttle
            };
            var payment = new UpdatePaymentRequestModel
            {
                StudentId = request.StudentId,
                Payment = request.Payment,
                TotalAmount = request.TotalAmount,
                Balance = request.Balance

            };

            await SessionRepository.UpdateSessionOneByStudentIdAsync(sessionOne);
            await SessionRepository.UpdateSessionTwoByStudentIdAsync(sessionTwo);
            await SessionRepository.UpdateSessionThreeByStudentIdAsync(sessionThree);

            await PaymentRepository.UpdatePaymentByStudentIdAsync(payment);

            return await StudentRepository.UpdateStudentByStudentIdAsync(student);
            
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            await PaymentRepository.DeletePaymentAsync(studentId);
            await SessionRepository.DeleteSessionOneAsync(studentId);
            await SessionRepository.DeleteSessionTwoAsync(studentId);
            await SessionRepository.DeleteSessionThreeAsync(studentId);

            await StudentRepository.DeleteStudentAsync(studentId);
        }

        public async Task<IEnumerable<StudentSchedule>> GetStudentScheduleByDateAsync(DateTime date, string schedule, string sessonLocation)
        {
            return await StudentRepository.GetStudentScheduleByDateAsync(date, schedule, sessonLocation);
        }

        public async Task<IEnumerable<ShuttleSchedule>> GetShuttleScheduleByDateAsync(DateTime date, string schedule)
        {
            return await StudentRepository.GetShuttleScheduleByDateAsync(date, schedule);
        }
    }
}
