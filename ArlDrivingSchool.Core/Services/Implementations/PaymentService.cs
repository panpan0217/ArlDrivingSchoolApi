using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository PaymentRepository { get; }

        public PaymentService(IPaymentRepository paymentRepository)
        {
            PaymentRepository = paymentRepository;
        }

        public async Task<int> GetMonthlyIncomeAsync()
        {
            return await PaymentRepository.GetMonthlyIncomeAsync();
        }

        public async Task<int> GetWeeklyIncomeAsync()
        {
            return await PaymentRepository.GetWeeklyIncomeAsync();
        }

        public async Task<int> GetDailyIncomeAsync()
        {
            return await PaymentRepository.GetDailyIncomeAsync();
        }

        public async Task DeleteSubPaymentAsync(int subPaymentId)
        {
            await PaymentRepository.DeleteSubPaymentAsync(subPaymentId);
        }
        public async Task DeletePDCSubPaymentAsync(int subPaymentId)
        {
            await PaymentRepository.DeletePDCSubPaymentAsync(subPaymentId);
        }
    }
}
