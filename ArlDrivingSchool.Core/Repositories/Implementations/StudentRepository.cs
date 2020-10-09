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

        public async Task<int> CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel)
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
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return studentId;
        }

        public async Task<bool> UpdateStudentByStudentIdAsync(Student student)
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
                student.Remarks

            };

            var result = await connection.ExecuteAsync("users.uspUpdateStudentByStudentId",
                                                        request, 
                                                        commandType: CommandType.StoredProcedure);
          

            return result > 0;
        }
    }
}
