using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Repositories.ObjectRelationalMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using ArlDrivingSchool.Core.Models.Users;
using ArlDrivingSchool.Core.DataTransferObject.Response;
using ArlDrivingSchool.Core.Models.Payments;
using ArlDrivingSchool.Core.Models.Sessions;
using ArlDrivingSchool.Core.DataTransferObject.Request;
using System.Linq;

namespace ArlDrivingSchool.Core.Repositories.Implementations
{
    public class StudentRepository : DapperRepository, IStudentRepository
    {
        private IConfiguration Configuration { get; }

        public StudentRepository(IConfiguration configuration)
            : base(configuration)
        {
            Configuration = configuration;
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
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var students = await connection.QueryAsync<Student>("users.uspGetAllStudent"
                                                                , commandType: CommandType.StoredProcedure);
            return students;
        }

        public async Task<PDCStudent> GetPDCStudentById(int pDCStudentId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var parameter = new
            {
                Id = pDCStudentId
            };

            var pDCStudent = await connection.QuerySingleAsync<PDCStudent>(
                   "[users].[uspGetPDCStudentById]",
                   param: parameter,
                   commandType: CommandType.StoredProcedure
               );

            return pDCStudent;
        }

        public async Task<StudentDetails> GetStudentByIdAsync(int studentId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var students = await connection.QueryAsync<StudentWithStatus, Payment, SessionOne, SessionTwo,
                                                                            SessionThree, StudentDetails>(
               "[users].[uspGetStudentWithDetailsById]",
               map: (studentWithStatus, payment, sessionOne, sessionTwo, sessionThree) =>
               {
                   return new StudentDetails
                   {
                       StudentWithStatus = studentWithStatus,
                       Payment = payment,
                       SessionOne = sessionOne,
                       SessionTwo = sessionTwo,
                       SessionThree = sessionThree
                   };
               },
               new
               {
                   StudentId = studentId
               },
               splitOn: "StudentId,PaymentId,SessionOneId,SessionTwoId,SessionThreeId",
               commandType: CommandType.StoredProcedure);

            return students.First();
        }

        public async Task<PDCStudentDetails> GetPDCStudentWithDetailsByIdAsync(int studentId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var pdcStudents = await connection.QueryAsync<PDCStudentWithStatus, PDCPayment, PDCStudentDetails>(
               "[users].[uspGetPDCStudentWithDetailsById]",
               map: (pdcStudentWithStatus, pdcPayment) =>
               {
                   return new PDCStudentDetails
                   {
                       PDCStudentWithStatus = pdcStudentWithStatus,
                       PDCPayment = pdcPayment
                   };
               },
               new
               {
                   PDCStudentId = studentId
               },
               splitOn: "PDCStudentId,PDCPaymentId",
               commandType: CommandType.StoredProcedure);

            return pdcStudents.First(); ;
        }

        public async Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsAsync()
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var students = await connection.QueryAsync<StudentWithStatus, Payment, SessionOne, SessionTwo,
                                                                            SessionThree, StudentDetails>(
               "users.uspGetAllStudentWithDetails",
               map: (studentWithStatus, payment, sessionOne, sessionTwo, sessionThree) =>
               {
                   return new StudentDetails
                   {
                       StudentWithStatus = studentWithStatus,
                       Payment = payment,
                       SessionOne = sessionOne,
                       SessionTwo = sessionTwo,
                       SessionThree = sessionThree
                   };
               },
               splitOn: "StudentId,PaymentId,SessionOneId,SessionTwoId,SessionThreeId",
               commandType: CommandType.StoredProcedure);

            return students;
        }

        public async Task<IEnumerable<StudentDetails>> GetStudentWithDetailsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var students = await connection.QueryAsync<StudentWithStatus, Payment, SessionOne, SessionTwo,
                                                                            SessionThree, StudentDetails>(
               "[users].[uspGetStudentWithDetailsByDateRange]",

               map: (studentWithStatus, payment, sessionOne, sessionTwo, sessionThree) =>
               {
                   return new StudentDetails
                   {
                       StudentWithStatus = studentWithStatus,
                       Payment = payment,
                       SessionOne = sessionOne,
                       SessionTwo = sessionTwo,
                       SessionThree = sessionThree
                   };
               },
               new
               {
                   StartDate = startDate,
                   EndDate = endDate
               },
               splitOn: "StudentId,PaymentId,SessionOneId,SessionTwoId,SessionThreeId",

               commandType: CommandType.StoredProcedure);

            return students;
        }

        public async Task<IEnumerable<PDCStudentDetails>> GetPDCStudentWithDetailsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var pdcStudents = await connection.QueryAsync<PDCStudentWithStatus, PDCPayment, PDCStudentDetails>(
               "[users].[uspGetPDCStudentWithDetailsByDateRange]",
               map: (pdcStudentWithStatus, pdcPayment) =>
               {
                   return new PDCStudentDetails
                   {
                       PDCStudentWithStatus = pdcStudentWithStatus,
                       PDCPayment = pdcPayment
                   };
               },
               new
               {
                   StartDate = startDate,
                   EndDate = endDate
               },
               splitOn: "PDCStudentId,PDCPaymentId",
               commandType: CommandType.StoredProcedure);

            return pdcStudents;
        }

        public async Task<int> CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel, DateTime? acesSaveDate, string createdBy)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var studentId = await connection.ExecuteScalarAsync<int>("[users].[uspInsertStudent]",
                                                                    new
                                                                    {
                                                                        requestModel.FirstName,
                                                                        requestModel.LastName,
                                                                        requestModel.Email,
                                                                        requestModel.Location,
                                                                        requestModel.DateOfBirth,
                                                                        requestModel.FBContact,
                                                                        requestModel.Mobile,
                                                                        requestModel.StudentStatusId,
                                                                        requestModel.TDCStatusId,
                                                                        requestModel.ACESStatusId,
                                                                        requestModel.Remarks,
                                                                        CreatedBy = createdBy,
                                                                        requestModel.AuthenticatedBy,
                                                                        requestModel.ClassType,
                                                                        requestModel.SessionEmail,
                                                                        requestModel.DriveSafeStatusId,
                                                                        requestModel.Certified,
                                                                        requestModel.TextForm,
                                                                        requestModel.EnrollmentModeId,
                                                                        requestModel.UserId,
                                                                        requestModel.OfficeId,
                                                                        AcesSaveDate = acesSaveDate,
                                                                        requestModel.OtherEnrollmentMode,
                                                                        requestModel.DateRegistered
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return studentId;
        }

        public async Task<bool> UpdateStudentByStudentIdAsync(Student student, DateTime? acesSaveDate, string updatedBy)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var request = new
            {
                student.StudentId,
                student.FirstName,
                student.LastName,
                student.Email,
                student.Location,
                student.DateOfBirth,
                student.FBContact,
                student.Mobile,
                student.StudentStatusId,
                student.TDCStatusId,
                student.ACESStatusId,
                student.Remarks,
                student.DateRegistered,
                student.AuthenticatedBy,
                ClassType = student.ClassType,
                SessionEmail = student.SessionEmail,
                DriveSafeStatusId = student.DriveSafeStatusId,
                student.TextForm,
                UpdatedBy = updatedBy,
                student.OfficeId,
                student.EnrollmentModeId,
                student.UserId,
                AcesSaveDate = acesSaveDate,
                student.OtherEnrollmentMode
            };

            var result = await connection.ExecuteAsync("users.uspUpdateStudentByStudentId",
                                                        request,
                                                        commandType: CommandType.StoredProcedure);


            return result > 0;
        }

        public async Task<Student> GetStudentInfoById(int studentId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var parameter = new
            {
                StudentId = studentId
            };

            var student = await connection.QuerySingleAsync<Student>(
                   "[users].[uspGetStudentId]",
                   param: parameter,
                   commandType: CommandType.StoredProcedure
               );

            return student;
        }

        public async Task<int> DeleteStudentAsync(int studentId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));


            return await connection.ExecuteAsync("[users].[uspDeleteStudent]",
                                                new
                                                {
                                                    StudentId = studentId
                                                },
                                                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<StudentSchedule>> GetStudentScheduleByDateAsync(DateTime date, string schedule, string sessionLocation, int branchId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var parameter = new
            {
                Date = date,
                Schedule = schedule,
                SessionLocation = sessionLocation,
                BranchId = branchId
            };

            var studentSchedule = await connection.QueryAsync<StudentSchedule>(
                   "[users].[uspGetStudentScheduleByDate]",
                   param: parameter,
                   commandType: CommandType.StoredProcedure
               );

            return studentSchedule;
        }

        public async Task<IEnumerable<ShuttleSchedule>> GetShuttleScheduleByDateAsync(DateTime date, string schedule, int branchId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var parameter = new
            {
                Date = date,
                Schedule = schedule,
                BranchId = branchId
            };

            var shuttleSchedule = await connection.QueryAsync<ShuttleSchedule>(
                  "[users].[uspGetShuttleScheduleByDate]",
                  param: parameter,
                  commandType: CommandType.StoredProcedure
              );

            return shuttleSchedule;

        }
        
        public async Task<IEnumerable<PDCStudentDetails>> GetAllPDCStudentWithDetailsAsync()
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var pdcStudents = await connection.QueryAsync<PDCStudentWithStatus, PDCPayment, PDCStudentDetails>(
               "[users].[uspGetAllPDCStudentWithDetails]",
               map: (pdcStudentWithStatus, pdcPayment) =>
               {
                   return new PDCStudentDetails
                   {
                       PDCStudentWithStatus = pdcStudentWithStatus,
                       PDCPayment = pdcPayment
                   };
               },
               splitOn: "PDCStudentId,PDCPaymentId",
               commandType: CommandType.StoredProcedure);

            return pdcStudents;
        }

        public async Task<IEnumerable<PDCStudentDetails>> GetAllPDCStudentWithDetailsByFullNameAsync(string fullName)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var pdcStudents = await connection.QueryAsync<PDCStudentWithStatus, PDCPayment, PDCStudentDetails>(
               "[users].[uspGetAllPDCStudentWithDetailsByFullName]",
               map: (pdcStudentWithStatus, pdcPayment) =>
               {
                   return new PDCStudentDetails
                   {
                       PDCStudentWithStatus = pdcStudentWithStatus,
                       PDCPayment = pdcPayment
                   };
               },
                new
                {
                    FullName = fullName,
                },
               splitOn: "PDCStudentId,PDCPaymentId",
               commandType: CommandType.StoredProcedure);

            return pdcStudents;
        }

        public async Task<int> DeletePDCStudentAsync(int pdcStudentId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            return await connection.ExecuteAsync("[users].[uspDeletePDCStudent]",
                                                new
                                                {
                                                    PDCStudentId = pdcStudentId
                                                },
                                                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CreatePDCStudentWithDetailsAsync(PDCStudentFullDetailRequestModel requestModel, string createdBy)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var studentId = await connection.ExecuteScalarAsync<int>("[users].[uspInsertPDCStudent]",
                                                                    new
                                                                    {
                                                                        requestModel.FullName,
                                                                        requestModel.FBContact,
                                                                        requestModel.Mobile,
                                                                        requestModel.Location,
                                                                        requestModel.DateOfBirth,
                                                                        requestModel.ACESStatusId,
                                                                        requestModel.RestrictionId,
                                                                        requestModel.ATransmissionId,
                                                                        requestModel.A1TransmissionId,
                                                                        requestModel.BTransmissionId,
                                                                        requestModel.B1TransmissionId,
                                                                        requestModel.B2TransmissionId,
                                                                        requestModel.ACourseId,
                                                                        requestModel.A1CourseId,
                                                                        requestModel.BCourseId,
                                                                        requestModel.B1CourseId,
                                                                        requestModel.B2CourseId,
                                                                        requestModel.Remarks,
                                                                        requestModel.StudentPermit,
                                                                        CreatedBy = createdBy,
                                                                        requestModel.AuthenticatedBy,
                                                                        requestModel.Certified,
                                                                        requestModel.EnrollmentModeId,
                                                                        requestModel.OfficeId,
                                                                        requestModel.UserId,
                                                                        requestModel.TdcStudentId,
                                                                        requestModel.TransactionId,
                                                                        requestModel.OtherEnrollmentMode,
                                                                        requestModel.DateRegistered
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return studentId;
        }

        public async Task<bool> UpdatePDCStudentByStudentIdAsync(PDCStudent pdcStudent, string updatedBy)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var request = new
            {
                pdcStudent.PDCStudentId,
                pdcStudent.DateRegistered,
                pdcStudent.FullName,
                pdcStudent.Location,
                pdcStudent.DateOfBirth,
                pdcStudent.FBContact,
                pdcStudent.Mobile,
                pdcStudent.ACESStatusId,
                pdcStudent.RestrictionId,
                pdcStudent.ATransmissionId,
                pdcStudent.A1TransmissionId,
                pdcStudent.BTransmissionId,
                pdcStudent.B1TransmissionId,
                pdcStudent.B2TransmissionId,
                pdcStudent.ACourseId,
                pdcStudent.A1CourseId,
                pdcStudent.BCourseId,
                pdcStudent.B1CourseId,
                pdcStudent.B2CourseId,
                pdcStudent.Remarks,
                pdcStudent.StudentPermit,
                UpdatedBy = updatedBy,
                pdcStudent.AuthenticatedBy,
                pdcStudent.OfficeId,
                pdcStudent.EnrollmentModeId,
                pdcStudent.UserId,
                pdcStudent.TransactionId,
                pdcStudent.StudentId,
                pdcStudent.OtherEnrollmentMode

            };

            var result = await connection.ExecuteAsync("[users].[uspUpdatePDCStudentByStudentId]",
                                                        request,
                                                        commandType: CommandType.StoredProcedure);


            return result > 0;
        }

        public async Task<IEnumerable<StudentCertification>> GetStudentByParams(int certified, DateTime startDate, DateTime endDate)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            return await connection.QueryAsync<StudentCertification>(
                   "[users].[uspGetTDCStudentByParams]",
                   new
                   {
                       Certificated = certified,
                       StartDate = startDate,
                       EndDate = endDate

                   },
                   commandType: CommandType.StoredProcedure
               );

        }

        public async Task<IEnumerable<PDCStudentCertification>> GetPDCStudentByParams(int certified, DateTime startDate, DateTime endDate)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            return await connection.QueryAsync<PDCStudentCertification>(
                   "[users].[uspGetPDCStudentByParams]",
                   new
                   {
                       Certificated = certified,
                       StartDate = startDate,
                       EndDate = endDate
                   },
                   commandType: CommandType.StoredProcedure
               );
        }
        public async Task<IEnumerable<DEPStudentCertification>> GetDEPStudentByParams(int certified, DateTime startDate, DateTime endDate)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            return await connection.QueryAsync<DEPStudentCertification>(
                   "[users].[uspGetDEPStudentByParams]",
                   new
                   {
                       Certificated = certified,
                       StartDate = startDate,
                       EndDate = endDate
                   },
                   commandType: CommandType.StoredProcedure
               );
        }

        public async Task UpdateStudentCertificationByIdsAsync(string ids)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var result = await connection.ExecuteAsync("[users].[usp_UpdateStudentCertificationByIds]",
                                                      new
                                                      {
                                                          Ids = $",{ids},",
                                                          CurrentDate = GetPhilippineDateTime()
                                                      },
                                                      commandType: CommandType.StoredProcedure);
        }
        public async Task UpdatePDCStudentCertificationByIdsAsync(string ids)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var result = await connection.ExecuteAsync("[users].[uspUpdatePDCStudentCertificationByIds]",
                                                      new
                                                      {
                                                          Ids = $",{ids},",
                                                          CurrentDate = GetPhilippineDateTime()
                                                      },
                                                      commandType: CommandType.StoredProcedure);
        }
        public async Task UpdateDEPStudentCertificationByIdsAsync(string ids)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var result = await connection.ExecuteAsync("[users].[uspUpdateDEPStudentCertificationByIds]",
                                                      new
                                                      {
                                                          Ids = $",{ids},",
                                                          CurrentDate = GetPhilippineDateTime()
                                                      },
                                                      commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateUncertifiedStudentByIdAsync(int id)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var result = await connection.ExecuteAsync("[users].[uspUpdateUncertifiedStudentById]",
                                                      new
                                                      {
                                                          Id = id
                                                      },
                                                      commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateUncertifiedPDCStudentByIdAsync(int id)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var result = await connection.ExecuteAsync("[users].[uspUpdateUncertifiedPDCStudentById]",
                                                      new
                                                      {
                                                          Id = id
                                                      },
                                                      commandType: CommandType.StoredProcedure);
        }
        public async Task UpdateUncertifiedDEPStudentByIdAsync(int id)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var result = await connection.ExecuteAsync("[users].[uspUpdateUncertifiedDEPStudentById]",
                                                      new
                                                      {
                                                          Id = id
                                                      },
                                                      commandType: CommandType.StoredProcedure);
        }
        


        public async Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsByFullNameAsync(string firstName, string lastName)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var students = await connection.QueryAsync<StudentWithStatus, Payment, SessionOne, SessionTwo,
                                                                            SessionThree, StudentDetails>(
               "[users].[uspGetAllStudentWithDetailsByFullName]",
               map: (studentWithStatus, payment, sessionOne, sessionTwo, sessionThree) =>
               {
                   return new StudentDetails
                   {
                       StudentWithStatus = studentWithStatus,
                       Payment = payment,
                       SessionOne = sessionOne,
                       SessionTwo = sessionTwo,
                       SessionThree = sessionThree
                   };
               },
               new { 
                    FirstName = firstName,
                    LastName = lastName
               },
               splitOn: "StudentId,PaymentId,SessionOneId,SessionTwoId,SessionThreeId",
               commandType: CommandType.StoredProcedure);

            return students;
        }

        public async Task<int> CreateDEPStudentWithDetailsAsync(DEPStudentFullDetailsRequestModel requestModel, string createdBy)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var studentId = await connection.ExecuteScalarAsync<int>("[users].[uspInsertDEPStudent]",
                                                                    new
                                                                    {
                                                                        requestModel.FullName,
                                                                        requestModel.Email,
                                                                        requestModel.Location,
                                                                        requestModel.FBContact,
                                                                        requestModel.Mobile,
                                                                        requestModel.LicenseNumber,
                                                                        requestModel.ExpirationDate,
                                                                        requestModel.Remarks,
                                                                        CreatedBy = createdBy,
                                                                        requestModel.ClassType,
                                                                        requestModel.SessionEmail,
                                                                        requestModel.DriveSafeStatusId,
                                                                        requestModel.TextForm,
                                                                        requestModel.EnrollmentModeId,
                                                                        requestModel.OfficeId,
                                                                        requestModel.UserId,
                                                                        requestModel.OtherEnrollmentMode

                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return studentId;
        }

        public async Task<IEnumerable<DEPStudentDetails>> GetAllDEPStudentWithDetailsAsync(DateTime startDate, DateTime endDate)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var students = await connection.QueryAsync<DEPStudent, DEPPayment, DEPSession, DEPStudentDetails>(
               "[users].[uspGetAllDEPStudentWithDetails]",
               map: (studentWithStatus, payment, sessionOne) =>
               {
                   return new DEPStudentDetails
                   {
                       DEPStudent = studentWithStatus,
                       DEPPayment = payment,
                       DEPSession = sessionOne,
                   };
               },
                new
                {
                    StartDate = startDate,
                    EndDate = endDate
                },
               splitOn: "DEPStudentId,DEPPaymentId,DEPSessionId",
               commandType: CommandType.StoredProcedure);

            return students;
        }

        public async Task<bool> UpdateDEPStudentWithDetailsAsync(DEPStudentFullDetailsRequestModel requestModel, string createdBy)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var studentId = await connection.ExecuteAsync("[users].[uspUpdateDEPStudentByStudentId]",
                                                                    new
                                                                    {
                                                                        requestModel.DEPStudentId,
                                                                        requestModel.FullName,
                                                                        requestModel.Email,
                                                                        requestModel.Location,
                                                                        requestModel.FBContact,
                                                                        requestModel.Mobile,
                                                                        requestModel.LicenseNumber,
                                                                        requestModel.ExpirationDate,
                                                                        requestModel.Remarks,
                                                                        requestModel.DateRegistered,
                                                                        UpdatedBy = createdBy,
                                                                        requestModel.ClassType,
                                                                        requestModel.SessionEmail,
                                                                        requestModel.DriveSafeStatusId,
                                                                        requestModel.TextForm,
                                                                        requestModel.EnrollmentModeId,
                                                                        requestModel.OfficeId,
                                                                        requestModel.UserId,
                                                                        requestModel.OtherEnrollmentMode

                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return studentId > 0;
        }

        public async Task<IEnumerable<DEPStudentSchedule>> GetDEPStudentScheduleByDateAsync(DateTime date, string schedule, string sessionLocation, int branchId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var parameter = new
            {
                Date = date,
                Schedule = schedule,
                SessionLocation = sessionLocation,
                BranchId = branchId
            };

            var studentSchedule = await connection.QueryAsync<DEPStudentSchedule>(
                   "[users].[uspGetDEPStudentScheduleByDate]",
                   param: parameter,
                   commandType: CommandType.StoredProcedure
               );

            return studentSchedule;
        }

        public async Task<DEPStudentDetails> GetDEPStudentByIdAsync(int studentId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var student = await connection.QueryAsync<DEPStudent, DEPPayment, DEPSession, DEPStudentDetails>(
               "[users].[uspGetDEPStudentWithById]",
               map: (studentWithStatus, payment, sessionOne) =>
               {
                   return new DEPStudentDetails
                   {
                       DEPStudent = studentWithStatus,
                       DEPPayment = payment,
                       DEPSession = sessionOne,
                   };
               },
                new
                {
                    StudentId = studentId,
                },
               splitOn: "DEPStudentId,DEPPaymentId,DEPSessionId",
               commandType: CommandType.StoredProcedure);

            return student.FirstOrDefault();
        }

        public async Task<IEnumerable<TotalStudentAndCertification>> GetTotalStudentAndCertificationAsync(DateTime startDate, DateTime endDate)
        {
            return await QueryAsync<TotalStudentAndCertification>("[users].[uspGetTotalStudentAndCertification]",
                new { StartDate = startDate,
                      EndDate = endDate
                    });
        }

        public async Task<IEnumerable<DEPStudentDetails>> GetAllDEPStudentWithDetailsByFullNameAsync(string fullName)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var students = await connection.QueryAsync<DEPStudent, DEPPayment, DEPSession, DEPStudentDetails>(
               "[users].[uspGetAllDEPStudentWithDetailsByFullName]",
               map: (studentWithStatus, payment, sessionOne) =>
               {
                   return new DEPStudentDetails
                   {
                       DEPStudent = studentWithStatus,
                       DEPPayment = payment,
                       DEPSession = sessionOne,
                   };
               },
                new
                {
                    FullName = fullName,
                },
               splitOn: "DEPStudentId,DEPPaymentId,DEPSessionId",
               commandType: CommandType.StoredProcedure);

            return students;
        }
    }
}
