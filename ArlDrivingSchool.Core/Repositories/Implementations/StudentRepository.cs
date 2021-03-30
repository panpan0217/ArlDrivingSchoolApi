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

        public async Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsAsync()
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var students = await connection.QueryAsync<StudentWithStatus, Payment, SessionOne,SessionTwo, 
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

        public async Task<int> CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel, string createdBy)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var studentId = await connection.ExecuteScalarAsync<int>("[users].[uspInsertStudent]",
                                                                    new
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
                                                                        CreatedBy = createdBy
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return studentId;
        }

        public async Task<bool> UpdateStudentByStudentIdAsync(Student student, string updatedBy)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var request = new
            {
                student.StudentId,
                student.FirstName,
                student.LastName,
                student.Email,
                student.Location,
                student.FBContact,
                student.Mobile,
                student.StudentStatusId,
                student.TDCStatusId,
                student.ACESStatusId,
                student.Remarks,
                student.DateRegistered,
                UpdatedBy = updatedBy

            };

            var result = await connection.ExecuteAsync("users.uspUpdateStudentByStudentId",
                                                        request, 
                                                        commandType: CommandType.StoredProcedure);
          

            return result > 0;
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

        public async Task<IEnumerable<StudentSchedule>> GetStudentScheduleByDateAsync(DateTime date, string schedule, string sessionLocation)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var parameter = new
            {
                Date = date,
                Schedule = schedule,
                SessionLocation = sessionLocation
            };

            var studentSchedule = await connection.QueryAsync<StudentSchedule>(
                   "[users].[uspGetStudentScheduleByDate]",
                   param: parameter,
                   commandType: CommandType.StoredProcedure
               );

            return studentSchedule;
        }

        public async Task<IEnumerable<ShuttleSchedule>> GetShuttleScheduleByDateAsync(DateTime date, string schedule)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var parameter = new
            {
                Date = date,
                Schedule = schedule
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
                                                                        FullName = requestModel.FullName,
                                                                        FBContact = requestModel.FBContact,
                                                                        Mobile = requestModel.Mobile,
                                                                        ACESStatusId = requestModel.ACESStatusId,
                                                                        RestrictionId = requestModel.RestrictionId,
                                                                        requestModel.ATransmissionId,
                                                                        requestModel.A1TransmissionId,
                                                                        requestModel.BTransmissionId,
                                                                        Remarks = requestModel.Remarks,
                                                                        StudentPermit = requestModel.StudentPermit,
                                                                        CreatedBy = createdBy
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
                pdcStudent.FBContact,
                pdcStudent.Mobile,
                pdcStudent.ACESStatusId,
                pdcStudent.RestrictionId,
                pdcStudent.ATransmissionId,
                pdcStudent.A1TransmissionId,
                pdcStudent.BTransmissionId,
                pdcStudent.Remarks,
                pdcStudent.StudentPermit,
                UpdatedBy = updatedBy

            };

            var result = await connection.ExecuteAsync("[users].[uspUpdatePDCStudentByStudentId]",
                                                        request,
                                                        commandType: CommandType.StoredProcedure);


            return result > 0;
        }

        public async Task<IEnumerable<StudentCertification>> GetStudentByParams(int certified)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            return await connection.QueryAsync<StudentCertification>(
                   "[users].[uspGetTDCStudentByParams]",
                   new {
                        Certificated = certified
                   },
                   commandType: CommandType.StoredProcedure
               );

        }

        public async Task<IEnumerable<PDCStudentCertification>> GetPDCStudentByParams(int certified)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            return await connection.QueryAsync<PDCStudentCertification>(
                   "[users].[uspGetPDCStudentByParams]",
                   new
                   {
                       Certificated = certified
                   },
                   commandType: CommandType.StoredProcedure
               );
        }

        public async Task UpdateStudentCertificationByIdsAsync(string ids)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var result = await connection.ExecuteAsync("[users].[usp_UpdateStudentCertificationByIds]",
                                                      new { 
                                                        Ids = $",{ids},"
                                                      },
                                                      commandType: CommandType.StoredProcedure);
        }
        public async Task UpdatePDCStudentCertificationByIdsAsync(string ids)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var result = await connection.ExecuteAsync("[users].[uspUpdatePDCStudentCertificationByIds]",
                                                      new
                                                      {
                                                          Ids = $",{ids},"
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
    }
}
