using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.Models.Payments;
using ArlDrivingSchool.Core.Models.Users;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Repositories.ObjectRelationalMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
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

        public async Task SaveOrUpdatePaymentAsync(SaveUpdatePaymentRequestModel paymentRequest)
        {
            using var _connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            try
            {
                // Save or update the Payment
                // Save or update the Payment
                if (paymentRequest.PaymentId == 0)
                {
                    const string insertPaymentSql = @"
                            INSERT INTO [payments].Payment
                            (StudentId, TotalAmount, Payment, Balance, PaymentModeId, [PaymentDate])
                            VALUES 
                            (@StudentId, @TotalAmount, @Payment, @Balance, @PaymentModeId, GETUTCDATE());
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                    paymentRequest.PaymentId = await _connection.ExecuteScalarAsync<int>(
                        insertPaymentSql, paymentRequest);
                }
                else
                {
                    const string updatePaymentSql = @"
                    UPDATE [payments].Payment
	                SET
	                 TotalAmount = @TotalAmount
	                ,Payment = @Payment
	                ,Balance = @Balance
	                ,PaymentModeId = @PaymentModeId
                    OUTPUT INSERTED.PaymentId
	                WHERE StudentId = @StudentId;";

                    paymentRequest.PaymentId = await _connection.QuerySingleAsync<int>(
                                    updatePaymentSql,
                                    paymentRequest
                                );
                }
               
                // Save or update SubPayments
                if (paymentRequest.SubPayments != null)
                {
                    foreach (var subPayment in paymentRequest.SubPayments)
                    {
                        subPayment.PaymentId = paymentRequest.PaymentId;

                        if (subPayment.SubPaymentId == 0)
                        {
                            const string insertSubPaymentSql = @"
                            INSERT INTO [payments].SubPayment
                            (PaymentId, Payment, PaymentModeId, [PaymentDate])
                            VALUES 
                            (@PaymentId, @Payment, @PaymentModeId, GETUTCDATE());
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                            subPayment.SubPaymentId = await _connection.ExecuteScalarAsync<int>(
                                insertSubPaymentSql, subPayment);
                        }
                        else
                        {
                            const string updateSubPaymentSql = @"
                            UPDATE [payments].SubPayment
                            SET 
                                PaymentId = @PaymentId,
                                Payment = @Payment,
                                PaymentModeId = @PaymentModeId
                            WHERE SubPaymentId = @SubPaymentId;";

                            await _connection.ExecuteAsync(updateSubPaymentSql, subPayment);
                        }
                    }
                }

            }
            catch
            {
            }
            finally
            {
            }
        }

        public async Task DeleteSubPaymentAsync(int subPaymentId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            const string deleteSubPaymentSql = @"
                DELETE FROM [payments].SubPayment
                WHERE SubPaymentId = @SubPaymentId;";

            await connection.ExecuteAsync(deleteSubPaymentSql, new { SubPaymentId = subPaymentId });
        }

        public async Task DeletePDCSubPaymentAsync(int subPaymentId)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            const string deleteSubPaymentSql = @"
                DELETE FROM [payments].PDCSubPayment
                WHERE PDCSubPaymentId = @PDCSubPaymentId;";

            await connection.ExecuteAsync(deleteSubPaymentSql, new { PDCSubPaymentId = subPaymentId });
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

        public async Task SaveOrUpdatePDCPaymentAsync(SaveUpdatePDCPaymentRequestModel paymentRequest)
        {
            using var _connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));

            try
            {
                // Save or update the Payment
                if (paymentRequest.PDCPaymentId == 0)
                {
                    const string insertPaymentSql = @"
                            INSERT INTO [payments].PDCPayment
                            (PDCStudentId, TotalAmount, Payment, Balance, PaymentModeId, [PaymentDate])
                            VALUES 
                            (@PDCStudentId, @TotalAmount, @Payment, @Balance, @PaymentModeId, GETUTCDATE());
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                    paymentRequest.PDCPaymentId = await _connection.ExecuteScalarAsync<int>(
                        insertPaymentSql, paymentRequest);
                }
                else
                {
                    const string updatePaymentSql = @"
                    UPDATE [payments].PDCPayment
	                SET
	                 TotalAmount = @TotalAmount
	                ,Payment = @Payment
	                ,Balance = @Balance
	                ,PaymentModeId = @PaymentModeId
                    OUTPUT INSERTED.PDCPaymentId
	                WHERE PDCStudentId = @PDCStudentId;";
                    paymentRequest.PDCPaymentId = await _connection.QuerySingleAsync<int>(
                               updatePaymentSql,
                               paymentRequest
                           );
                }
                
                // Save or update SubPayments
                if (paymentRequest.PDCSubPayments != null)
                {
                    foreach (var subPayment in paymentRequest.PDCSubPayments)
                    {
                        subPayment.PDCPaymentId = paymentRequest.PDCPaymentId;

                        if (subPayment.PDCSubPaymentId == 0)
                        {
                            const string insertSubPaymentSql = @"
                            INSERT INTO [payments].PDCSubPayment
                            (PDCPaymentId, Payment, PaymentModeId, [PaymentDate])
                            VALUES 
                            (@PDCPaymentId, @Payment, @PaymentModeId, GETUTCDATE());
                            SELECT CAST(SCOPE_IDENTITY() as int);";

                            subPayment.PDCSubPaymentId = await _connection.ExecuteScalarAsync<int>(
                                insertSubPaymentSql, subPayment);
                        }
                        else
                        {
                            const string updateSubPaymentSql = @"
                            UPDATE [payments].PDCSubPayment
                            SET 
                                PDCPaymentId = @PDCPaymentId,
                                Payment = @Payment,
                                PaymentModeId = @PaymentModeId
                            WHERE PDCSubPaymentId = @PDCSubPaymentId;";

                            await _connection.ExecuteAsync(updateSubPaymentSql, subPayment);
                        }
                    }
                }

            }
            catch
            {
            }
            finally
            {
            }
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
