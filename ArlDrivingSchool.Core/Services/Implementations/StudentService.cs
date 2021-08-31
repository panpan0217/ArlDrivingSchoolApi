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
        private IUserRepository UserRepository { get; }
        public StudentService(IStudentRepository studentRepository, ISessionRepository sessionRepository, 
            IPaymentRepository paymentRepository, IUserRepository userRepository)
        {
            StudentRepository = studentRepository;
            SessionRepository = sessionRepository;
            PaymentRepository = paymentRepository;
            UserRepository = userRepository;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await StudentRepository.GetAllAsync();
        }

        public async Task<PDCStudent> GetPDCStudentByIdAsync(int pDCStudentId)
        {
            return await StudentRepository.GetPDCStudentById(pDCStudentId);
        }

        public async Task<StudentDetails> GetStudentByIdAsync(int studentId)
        {
            return await StudentRepository.GetStudentByIdAsync(studentId);
        }

        public async Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsAsync()
        {
            return await StudentRepository.GetAllStudentWithDetailsAsync();
        }
        public async Task<IEnumerable<StudentDetails>> GetStudentWithDetailsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await StudentRepository.GetStudentWithDetailsByDateRangeAsync(startDate, endDate);
        }
        public async Task CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel, int userId)
        {
            var user = await UserRepository.GetUserByUserId(userId);
            var studentRequest = new StudentFullDetailsRequestModel
            {
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
                AuthenticatedBy = requestModel.AuthenticatedBy,
                ClassType = requestModel.ClassType,
                SessionEmail = requestModel.SessionEmail,
                DriveSafeStatusId = requestModel.DriveSafeStatusId,
                Certified = requestModel.Certified
            };
            var studentId = await StudentRepository.CreateStudentWithDetailsAsync(studentRequest, $"{user.FirstName} {user.LastName}");

            await SessionRepository.CreateSessionOneAsync(
                studentId: studentId,
                sessionDate: requestModel.SessionOneDate,
                schedule: requestModel.SessionOneSchedule,
                shuttle: requestModel.SessionOneShuttle,
                sessionLocation: requestModel.SessionOneLocation,
                branchId: requestModel.SessionOneBranchId
                );
         
            await SessionRepository.CreateSessionTwoAsync(
                studentId: studentId,
                sessionDate: requestModel.SessionTwoDate,
                schedule: requestModel.SessionTwoSchedule,
                shuttle: requestModel.SessionTwoShuttle,
                sessionLocation: requestModel.SessionTwoLocation,
                branchId : requestModel.SessionTwoBranchId
                );
            
            await SessionRepository.CreateSessionThreeAsync(
                studentId: studentId,
                sessionDate: requestModel.SessionThreeDate,
                schedule: requestModel.SessionThreeSchedule,
                shuttle: requestModel.SessionThreeShuttle,
                sessionLocation: requestModel.SessionThreeLocation,
                 branchId: requestModel.SessionThreeBranchId
                );

            await PaymentRepository.CreatePaymentAsync(
                studentId,
                totalAmount: requestModel.TotalAmount,
                payment: requestModel.Payment,
                balance: requestModel.Balance
                );
        }

        public async Task<bool> UpdateStudentByStudentIdAsync(UpdateStudentDetailsRequestModel request, int userId)
        {
            var user = await UserRepository.GetUserByUserId(userId);
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
                DateRegistered = request.DateRegistered,
                AuthenticatedBy = request.AuthenticatedBy,
                ClassType = request.ClassType,
                SessionEmail = request.SessionEmail,
                DriveSafeStatusId = request.DriveSafeStatusId
            };

            var sessionOne = new UpdateSessionRequestModel
            {
                StudentId = request.StudentId,
                SessionDate = request.SessionOneDate,
                Schedule = request.SessionOneSchedule,
                SessionLocation = request.SessionOneLocation,
                Shuttle = request.SessionOneShuttle,
                SessionBranchId =  request.SessionOneBranchId
            };

            var sessionTwo = new UpdateSessionRequestModel
            {
                StudentId = request.StudentId,
                SessionDate = request.SessionTwoDate,
                Schedule = request.SessionTwoSchedule,
                SessionLocation = request.SessionTwoLocation,
                Shuttle = request.SessionTwoShuttle,
                SessionBranchId = request.SessionTwoBranchId
            };

            var sessionThree = new UpdateSessionRequestModel
            {
                StudentId = request.StudentId,
                SessionDate = request.SessionThreeDate,
                Schedule = request.SessionThreeSchedule,
                SessionLocation = request.SessionThreeLocation,
                Shuttle = request.SessionThreeShuttle,
                SessionBranchId = request.SessionThreeBranchId
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

            return await StudentRepository.UpdateStudentByStudentIdAsync(student, $"{user.FirstName} {user.LastName}");
            
        }

        public async Task DeleteStudentAsync(int studentId)
        {
            await PaymentRepository.DeletePaymentAsync(studentId);
            await SessionRepository.DeleteSessionOneAsync(studentId);
            await SessionRepository.DeleteSessionTwoAsync(studentId);
            await SessionRepository.DeleteSessionThreeAsync(studentId);

            await StudentRepository.DeleteStudentAsync(studentId);
        }

        public async Task<IEnumerable<StudentSchedule>> GetStudentScheduleByDateAsync(DateTime date, string schedule, string sessonLocation, int branchId)
        {
            return await StudentRepository.GetStudentScheduleByDateAsync(date, schedule, sessonLocation, branchId);
        }

        public async Task<IEnumerable<ShuttleSchedule>> GetShuttleScheduleByDateAsync(DateTime date, string schedule, int branchId)
        {
            return await StudentRepository.GetShuttleScheduleByDateAsync(date, schedule, branchId);
        }

        public async Task<IEnumerable<PDCStudentDetails>> GetAllPDCStudentWithDetailsAsync()
        {
            return await StudentRepository.GetAllPDCStudentWithDetailsAsync();
        }

        public async Task<IEnumerable<PDCStudentDetails>> GetAllPDCStudentWithDetailsByFullNameAsync(string fullName)
        {
            return await StudentRepository.GetAllPDCStudentWithDetailsByFullNameAsync(fullName);
        }

        public async Task DeletePDCStudentAsync(int pdcStudentId)
        {
            await StudentRepository.DeletePDCStudentAsync(pdcStudentId);
        }

        public async Task CreatePDCStudentWithDetailsAsync(PDCStudentFullDetailRequestModel requestModel, int userId)
        {
            var user = await UserRepository.GetUserByUserId(userId);

            var student = new PDCStudentFullDetailRequestModel
            {
                PDCStudentId = requestModel.PDCStudentId,
                DateRegistered = requestModel.DateRegistered,
                FullName = requestModel.FullName,
                FBContact = requestModel.FBContact,
                Mobile = requestModel.Mobile,
                ACESStatusId = requestModel.ACESStatusId,
                RestrictionId = requestModel.RestrictionId,
                ATransmissionId = requestModel.ATransmissionId,
                A1TransmissionId = requestModel.A1TransmissionId,
                BTransmissionId = requestModel.BTransmissionId,
                Remarks = requestModel.Remarks,
                StudentPermit = requestModel.StudentPermit,
                AuthenticatedBy = requestModel.AuthenticatedBy,
                Certified = requestModel.Certified

            };

            var pdcStudentId = await StudentRepository.CreatePDCStudentWithDetailsAsync(student, $"{user.FirstName} {user.LastName}");

            await PaymentRepository.CreatePDCPaymentAsync(
                pdcStudentId,
                totalAmount: requestModel.TotalAmount,
                payment: requestModel.Payment,
                balance: requestModel.Balance
                );
        }

        public async Task<bool> UpdatePDCStudentByStudentIdAsync(PDCStudentFullDetailRequestModel request, int userId)
        {
            var user = await UserRepository.GetUserByUserId(userId);
            var student = new PDCStudent
            {
                PDCStudentId = request.PDCStudentId,
                DateRegistered = request.DateRegistered,
                FullName = request.FullName,
                FBContact = request.FBContact,
                Mobile = request.Mobile,
                ACESStatusId = request.ACESStatusId,
                RestrictionId = request.RestrictionId,
                ATransmissionId = request.ATransmissionId,
                A1TransmissionId = request.A1TransmissionId,
                BTransmissionId = request.BTransmissionId,
                Remarks = request.Remarks,
                StudentPermit = request.StudentPermit,
                AuthenticatedBy = request.AuthenticatedBy
               
            };

            var payment = new UpdatePaymentRequestModel
            {
                StudentId = request.PDCStudentId,
                Payment = request.Payment,
                TotalAmount = request.TotalAmount,
                Balance = request.Balance

            };

            await PaymentRepository.UpdatePDCPaymentByStudentIdAsync(payment);
            return await StudentRepository.UpdatePDCStudentByStudentIdAsync(student, $"{user.FirstName} {user.LastName}");

        }

        public async Task<IEnumerable<StudentCertification>> GetStudentByParams(int certified)
        {
            return await StudentRepository.GetStudentByParams(certified);
        }

        public async Task<IEnumerable<PDCStudentCertification>> GetPDCStudentByParams(int certified)
        {
            return await StudentRepository.GetPDCStudentByParams(certified);
        }

        public async Task UpdateStudentCertificationByIdsAsync(string ids)
        {
            await StudentRepository.UpdateStudentCertificationByIdsAsync(ids);
        }
        public async Task UpdatePDCStudentCertificationByIdsAsync(string ids)
        {
            await StudentRepository.UpdatePDCStudentCertificationByIdsAsync(ids);
        }

        public async Task UpdateUncertifiedStudentByIdAsync(int id)
        {
            await StudentRepository.UpdateUncertifiedStudentByIdAsync(id);
        }

        public async Task UpdateUncertifiedPDCStudentByIdAsync(int id)
        {
            await StudentRepository.UpdateUncertifiedPDCStudentByIdAsync(id);
        }

        public async Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsByFullNameAsync(string firstName, string lastName)
        {
            return await StudentRepository.GetAllStudentWithDetailsByFullNameAsync(firstName, lastName);
        }
    }
}
