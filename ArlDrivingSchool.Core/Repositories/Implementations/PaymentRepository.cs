using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Repositories.ObjectRelationalMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Implementations
{
    public class PaymentRepository : DapperRepository, IPaymentRepository
    {
        private IConfiguration Configuration { get; }

        public PaymentRepository(IConfiguration configuration)
            : base(configuration)
        {
            Configuration = configuration;
        }

        public async Task<int> CreatePaymentAsync(int studentId, int totalAmount, int payment, int balance, int paymentModeId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var paymentId = await connection.ExecuteScalarAsync<int>("[payments].[uspInsertPayment]",
                                                                    new
                                                                    {
                                                                        StudentId = studentId,
                                                                        TotalAmount = totalAmount,
                                                                        Payment = payment,
                                                                        Balance = balance,
                                                                        PaymentModeId = paymentModeId,
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return paymentId;
        }

        public async Task<bool> UpdatePaymentByStudentIdAsync(UpdatePaymentRequestModel request)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var result = await connection.ExecuteAsync("[payments].[uspUpdatePaymentByStudentId]",
                                                    request,
                                                    commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<int> DeletePaymentAsync(int studentId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            return await connection.ExecuteAsync("[payments].[uspDeletePayment]",
                                                new
                                                {
                                                    StudentId = studentId
                                                },
                                                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> CreatePDCPaymentAsync(int pdcStudentId, int totalAmount, int payment, int balance, int paymentModeId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var paymentId = await connection.ExecuteScalarAsync<int>("[payments].[uspInsertPDCPayment]",
                                                                    new
                                                                    {
                                                                        PDCStudentId = pdcStudentId,
                                                                        TotalAmount = totalAmount,
                                                                        Payment = payment,
                                                                        Balance = balance,
                                                                        PaymentModeId = paymentModeId
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return paymentId;
        }

        public async Task<bool> UpdatePDCPaymentByStudentIdAsync(UpdatePaymentRequestModel request)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var result = await connection.ExecuteAsync("[payments].[uspUpdatePDCPaymentByStudentId]",
                                                    request,
                                                    commandType: CommandType.StoredProcedure);

            return result > 0;
        }

        public async Task<int> CreateDEPPaymentAsync(int studentId, int totalAmount, int payment, int balance)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var paymentId = await connection.ExecuteScalarAsync<int>("[payments].[uspInsertDEPPayment]",
                                                                    new
                                                                    {
                                                                        DEPStudentId = studentId,
                                                                        TotalAmount = totalAmount,
                                                                        Payment = payment,
                                                                        Balance = balance
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return paymentId;
        }

        public async Task<bool> UpdateDEPPaymentByStudentIdAsync(int studentId, int totalAmount, int payment, int balance)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var result = await connection.ExecuteAsync("[payments].[uspUpdateDEPPaymentByStudentId]",
                                                     new
                                                     {
                                                         DEPStudentId = studentId,
                                                         TotalAmount = totalAmount,
                                                         Payment = payment,
                                                         Balance = balance
                                                     },
                                                    commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}
