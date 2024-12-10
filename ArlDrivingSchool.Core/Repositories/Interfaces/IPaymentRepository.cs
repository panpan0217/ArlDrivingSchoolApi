using ArlDrivingSchool.Core.DataTransferObject.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<int> GetMonthlyIncomeAsync();
        Task<int> GetWeeklyIncomeAsync();
        Task<int> GetDailyIncomeAsync();
        Task<int> CreatePaymentAsync(int studentId, int totalAmount, int payment, int balance, int paymentModeId);
        Task<bool> UpdatePaymentByStudentIdAsync(UpdatePaymentRequestModel payment);
        Task SaveOrUpdatePaymentAsync(SaveUpdatePaymentRequestModel payment);
        Task SaveOrUpdatePDCPaymentAsync(SaveUpdatePDCPaymentRequestModel payment);
        Task<int> DeletePaymentAsync(int studentId);
        Task<int> CreatePDCPaymentAsync(int pdcStudentId, int totalAmount, int payment, int balance, int paymentModeId);

        Task<bool> UpdatePDCPaymentByStudentIdAsync(UpdatePaymentRequestModel payment);

        Task<int> CreateDEPPaymentAsync(int studentId, int totalAmount, int payment, int balance, int paymentModeId);
        Task<bool> UpdateDEPPaymentByStudentIdAsync(int studentId, int totalAmount, int payment, int balance, int paymentModeId);
        Task DeleteSubPaymentAsync(int subPaymentId);
        Task DeletePDCSubPaymentAsync(int subPaymentId);
    }

}
