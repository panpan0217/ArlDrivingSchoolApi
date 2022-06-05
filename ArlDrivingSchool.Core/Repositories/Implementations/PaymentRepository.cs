using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Repositories.ObjectRelationalMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
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

        public async Task<int> GetMonthlyIncomeAsync()
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var tdcIncome = await connection.ExecuteScalarAsync<int>("[payments].[uspGetTDCMonthlyIncome]"
                                                                , commandType: CommandType.StoredProcedure);
            var pdcIncome = await connection.ExecuteScalarAsync<int>("[payments].[uspGetPDCMonthlyIncome]"
                                                    , commandType: CommandType.StoredProcedure);
            var depIncome = await connection.ExecuteScalarAsync<int>("[payments].[uspGetDEPMonthlyIncome]"
                                                    , commandType: CommandType.StoredProcedure);

            return tdcIncome + pdcIncome + depIncome;
        }

        public async Task<int> GetWeeklyIncomeAsync()
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var tdcIncome = await connection.ExecuteScalarAsync<int>("[payments].[uspGetTDCWeeklyIncome]"
                                                                , commandType: CommandType.StoredProcedure);
            var pdcIncome = await connection.ExecuteScalarAsync<int>("[payments].[uspGetPDCWeeklyIncome]"
                                                    , commandType: CommandType.StoredProcedure);
            var depIncome = await connection.ExecuteScalarAsync<int>("[payments].[uspGetDEPWeeklyIncome]"
                                                    , commandType: CommandType.StoredProcedure);

            return tdcIncome + pdcIncome + depIncome;
        }

        public async Task<int> GetDailyIncomeAsync()
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var tdcIncome = await connection.ExecuteScalarAsync<int>("[payments].[uspGetTDCDailyIncome]"
                                                                , commandType: CommandType.StoredProcedure);
            var pdcIncome = await connection.ExecuteScalarAsync<int>("[payments].[uspGetPDCDailyIncome]"
                                                    , commandType: CommandType.StoredProcedure);
            var depIncome = await connection.ExecuteScalarAsync<int>("[payments].[uspGetDEPDailyIncome]"
                                                    , commandType: CommandType.StoredProcedure);

            return tdcIncome + pdcIncome + depIncome;
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

        public async Task<int> CreateDEPPaymentAsync(int studentId, int totalAmount, int payment, int balance, int paymentModeId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var paymentId = await connection.ExecuteScalarAsync<int>("[payments].[uspInsertDEPPayment]",
                                                                    new
                                                                    {
                                                                        DEPStudentId = studentId,
                                                                        TotalAmount = totalAmount,
                                                                        Payment = payment,
                                                                        Balance = balance,
                                                                        PaymentModeId = paymentModeId
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return paymentId;
        }

        public async Task<bool> UpdateDEPPaymentByStudentIdAsync(int studentId, int totalAmount, int payment, int balance, int paymentModeId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            var result = await connection.ExecuteAsync("[payments].[uspUpdateDEPPaymentByStudentId]",
                                                     new
                                                     {
                                                         DEPStudentId = studentId,
                                                         TotalAmount = totalAmount,
                                                         Payment = payment,
                                                         Balance = balance,
                                                         PaymentModeId = paymentModeId
                                                     },
                                                    commandType: CommandType.StoredProcedure);

            return result > 0;
        }
    }
}
