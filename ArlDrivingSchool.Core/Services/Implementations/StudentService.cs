using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.DataTransferObject.Response;
using ArlDrivingSchool.Core.Models.Users;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private DateTime GetPhilippineDateTime()
        {
            var utc = DateTime.UtcNow;
            TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");

            // it's a simple one-liner
            DateTime dateTime = TimeZoneInfo.ConvertTimeFromUtc(utc, tzi);
            return dateTime;
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

        public async Task<IEnumerable<PDCStudentDetails>> GetPDCStudentWithDetailsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await StudentRepository.GetPDCStudentWithDetailsByDateRangeAsync(startDate, endDate);
        }

        public async Task<int> CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel, int userId)
        {
            var user = await UserRepository.GetUserByUserId(userId);

            DateTime? acesSaveDate;

            if (requestModel.IsAcesDateSave == true)
            {
                acesSaveDate = GetPhilippineDateTime();
            }
            else
            {
                acesSaveDate = null;
            }
            //var studentRequest = new StudentFullDetailsRequestModel
            //{
            //    FirstName = requestModel.FirstName,
            //    LastName = requestModel.LastName,
            //    Email = requestModel.Email,
            //    Location = requestModel.Location,
            //    FBContact = requestModel.FBContact,
            //    Mobile = requestModel.Mobile,
            //    StudentStatusId = requestModel.StudentStatusId,
            //    TDCStatusId = requestModel.TDCStatusId,
            //    ACESStatusId = requestModel.ACESStatusId,
            //    Remarks = requestModel.Remarks,
            //    AuthenticatedBy = requestModel.AuthenticatedBy,
            //    ClassType = requestModel.ClassType,
            //    SessionEmail = requestModel.SessionEmail,
            //    DriveSafeStatusId = requestModel.DriveSafeStatusId,
            //    Certified = requestModel.Certified,
            //    EnrollmentModeId = requestModel.EnrollmentModeId,
            //    TextForm = requestModel.TextForm,
            //    OfficeId =requestModel.OfficeId,

            //};
            var studentId = await StudentRepository.CreateStudentWithDetailsAsync(requestModel, acesSaveDate, $"{user.FirstName} {user.LastName}");

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
            
            //await SessionRepository.CreateSessionThreeAsync(
            //    studentId: studentId,
            //    sessionDate: requestModel.SessionThreeDate,
            //    schedule: requestModel.SessionThreeSchedule,
            //    shuttle: requestModel.SessionThreeShuttle,
            //    sessionLocation: requestModel.SessionThreeLocation,
            //     branchId: requestModel.SessionThreeBranchId
            //    );

            await PaymentRepository.CreatePaymentAsync(
                studentId,
                requestModel.TotalAmount,
                requestModel.Payment,
                requestModel.Balance,
                requestModel.PaymentModeId
                );
            return studentId;
        }

        public async Task<bool> UpdateStudentByStudentIdAsync(UpdateStudentDetailsRequestModel request, int userId)
        {
            var user = await UserRepository.GetUserByUserId(userId);
            var studentInfo = await StudentRepository.GetStudentInfoById(request.StudentId);
            DateTime? acesSaveDate;

            if(request.IsAcesDateSave == true)
            {
                acesSaveDate = GetPhilippineDateTime();
            }
            else
            {
                if (studentInfo.AcesSaveDate != null)
                {
                    if(request.ACESStatusId == 1)
                        acesSaveDate = null;
                    else
                        acesSaveDate = studentInfo.AcesSaveDate;
                }
                else
                {
                    acesSaveDate = null;
                }
            }

            var student = new Student
            {
                StudentId = request.StudentId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Location = request.Location,
                DateOfBirth = request.DateOfBirth,
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
                DriveSafeStatusId = request.DriveSafeStatusId,
                TextForm = request.TextForm,
                EnrollmentModeId = request.EnrollmentModeId,
                OfficeId = request.OfficeId,
                UserId = request.UserId,
                OtherEnrollmentMode = request.OtherEnrollmentMode
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
                Balance = request.Balance,
                PaymentModeId = request.PaymentModeId
            };

            await SessionRepository.UpdateSessionOneByStudentIdAsync(sessionOne);
            await SessionRepository.UpdateSessionTwoByStudentIdAsync(sessionTwo);
            //await SessionRepository.UpdateSessionThreeByStudentIdAsync(sessionThree);

            await PaymentRepository.UpdatePaymentByStudentIdAsync(payment);

            return await StudentRepository.UpdateStudentByStudentIdAsync(student, acesSaveDate, $"{user.FirstName} {user.LastName}");
            
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
            var scheduleByDate = await StudentRepository.GetStudentScheduleByDateAsync(date, schedule, sessonLocation, branchId);
            scheduleByDate.ToList().ForEach(s => s.SessionsAttendedCount = s.SessionsAttended.Split(",").FirstOrDefault() == "" ? 0 : s.SessionsAttended.Split(",").Length);

            return scheduleByDate;

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

            var pdcStudentId = await StudentRepository.CreatePDCStudentWithDetailsAsync(requestModel, $"{user.FirstName} {user.LastName}");

            await PaymentRepository.CreatePDCPaymentAsync(
                pdcStudentId,
                totalAmount: requestModel.TotalAmount,
                payment: requestModel.Payment,
                balance: requestModel.Balance,
                requestModel.PaymentModeId
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
                Location = request.Location,
                DateOfBirth = request.DateOfBirth,
                FBContact = request.FBContact,
                Mobile = request.Mobile,
                ACESStatusId = request.ACESStatusId,
                RestrictionId = request.RestrictionId,
                ATransmissionId = request.ATransmissionId,
                A1TransmissionId = request.A1TransmissionId,
                BTransmissionId = request.BTransmissionId,
                B1TransmissionId = request.B1TransmissionId,
                B2TransmissionId = request.B2TransmissionId,
                ACourseId = request.ACourseId,
                A1CourseId = request.A1CourseId,
                BCourseId = request.BCourseId,
                B1CourseId = request.B1CourseId,
                B2CourseId = request.B2CourseId,
                Remarks = request.Remarks,
                StudentPermit = request.StudentPermit,
                AuthenticatedBy = request.AuthenticatedBy,
                EnrollmentModeId = request.EnrollmentModeId,
                UserId =request.UserId,
                OfficeId = request.OfficeId,
                TransactionId = request.TransactionId,
                StudentId = request.TdcStudentId,
                OtherEnrollmentMode = request.OtherEnrollmentMode
            };

            var payment = new UpdatePaymentRequestModel
            {
                StudentId = request.PDCStudentId,
                Payment = request.Payment,
                TotalAmount = request.TotalAmount,
                Balance = request.Balance,
                PaymentModeId = request.PaymentModeId
            };

            await PaymentRepository.UpdatePDCPaymentByStudentIdAsync(payment);
            return await StudentRepository.UpdatePDCStudentByStudentIdAsync(student, $"{user.FirstName} {user.LastName}");

        }

        public async Task<IEnumerable<StudentCertification>> GetStudentByParams(int certified, DateTime startDate, DateTime endDate)
        {
            return await StudentRepository.GetStudentByParams(certified, startDate, endDate);
        }

        public async Task<IEnumerable<PDCStudentCertification>> GetPDCStudentByParams(int certified, DateTime startDate, DateTime endDate)
        {
            return await StudentRepository.GetPDCStudentByParams(certified, startDate, endDate);
        }
        public async Task<IEnumerable<DEPStudentCertification>> GetDEPStudentByParams(int certified, DateTime startDate, DateTime endDate)
        {
            return await StudentRepository.GetDEPStudentByParams(certified, startDate, endDate);
        }

        public async Task UpdateStudentCertificationByIdsAsync(string ids)
        {
            await StudentRepository.UpdateStudentCertificationByIdsAsync(ids);
        }
        public async Task UpdatePDCStudentCertificationByIdsAsync(string ids)
        {
            await StudentRepository.UpdatePDCStudentCertificationByIdsAsync(ids);
        }

        public async Task UpdateDEPStudentCertificationByIdsAsync(string ids)
        {
            await StudentRepository.UpdateDEPStudentCertificationByIdsAsync(ids);
        }
        public async Task UpdateUncertifiedStudentByIdAsync(int id)
        {
            await StudentRepository.UpdateUncertifiedStudentByIdAsync(id);
        }

        public async Task UpdateUncertifiedPDCStudentByIdAsync(int id)
        {
            await StudentRepository.UpdateUncertifiedPDCStudentByIdAsync(id);
        }
        public async Task UpdateUncertifiedDEPStudentByIdAsync(int id)
        {
            await StudentRepository.UpdateUncertifiedDEPStudentByIdAsync(id);
        }
        public async Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsByFullNameAsync(string firstName, string lastName)
        {
            return await StudentRepository.GetAllStudentWithDetailsByFullNameAsync(firstName, lastName);
        }

        //DEP
        public async Task CreateDEPStudentWithDetailsAsync(DEPStudentFullDetailsRequestModel requestModel, int userId)
        {
            var user = await UserRepository.GetUserByUserId(userId);
            var studentId = await StudentRepository.CreateDEPStudentWithDetailsAsync(requestModel, $"{user.FirstName} {user.LastName}");


            await SessionRepository.CreateDEPSessionOneAsync(
                studentId: studentId,
                sessionDate: requestModel.SessionOneDate,
                schedule: requestModel.SessionOneSchedule,
                sessionLocation: requestModel.SessionOneLocation,
                branchId: requestModel.SessionOneBranchId
                );

            await PaymentRepository.CreateDEPPaymentAsync(
                studentId,
                totalAmount: requestModel.TotalAmount,
                payment: requestModel.Payment,
                balance: requestModel.Balance,
                requestModel.PaymentModeId
                );
        }

        public async Task<IEnumerable<DEPStudentDetails>> GetAllDEPStudentWithDetailsAsync(DateTime startDate, DateTime endDate)
        {
            return await StudentRepository.GetAllDEPStudentWithDetailsAsync(startDate, endDate);
        }

        public async Task<bool> UpdateStudentByStudentIdAsync(DEPStudentFullDetailsRequestModel requestModel, int userId)
        {
            var user = await UserRepository.GetUserByUserId(userId);
            await SessionRepository.UpdateDEPSessionOneByStudentIdAsync(
                studentId: requestModel.DEPStudentId,
                sessionDate: requestModel.SessionOneDate,
                schedule: requestModel.SessionOneSchedule,
                sessionLocation: requestModel.SessionOneLocation,
                branchId: requestModel.SessionOneBranchId
                );

            await PaymentRepository.UpdateDEPPaymentByStudentIdAsync(
               studentId: requestModel.DEPStudentId,
               totalAmount: requestModel.TotalAmount,
               payment: requestModel.Payment,
               balance: requestModel.Balance,
               requestModel.PaymentModeId
               );

            var student = await StudentRepository.UpdateDEPStudentWithDetailsAsync(requestModel, $"{user.FirstName} {user.LastName}");

            return student;

        }

        public async Task<IEnumerable<DEPStudentSchedule>> GetDEPStudentScheduleByDateAsync(DateTime date, string schedule, string sessionLocation, int branchId)
        {
            return await StudentRepository.GetDEPStudentScheduleByDateAsync(date, schedule, sessionLocation, branchId);
        }

        public async Task<DEPStudentDetails> GetDEPStudentByIdAsync(int studentId)
        {
            return await StudentRepository.GetDEPStudentByIdAsync(studentId);
        }

        public async Task<IEnumerable<TotalStudentAndCertification>> GetTotalStudentAndCertificationAsync(DateTime startDate, DateTime endDate)
        {
            return await StudentRepository.GetTotalStudentAndCertificationAsync(startDate, endDate);
        }

        public async Task<IEnumerable<DEPStudentDetails>> GetAllDEPStudentWithDetailsByFullNameAsync(string fullName)
        {
            return await StudentRepository.GetAllDEPStudentWithDetailsByFullNameAsync(fullName);
        }

        public async Task<PDCStudentDetails> GetPDCStudentWithDetailsByIdAsync(int studentId)
        {
            return await StudentRepository.GetPDCStudentWithDetailsByIdAsync(studentId);
        }
    }
}
