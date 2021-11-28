using ArlDrivingSchool.Core.Models.Setting;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Implementations
{
    public class BillingService : IBillingService
    {
        private IBillingRepository BillingRepository { get; }

        public BillingService(IBillingRepository billingRepository)
        {
            BillingRepository = billingRepository;
        }

        public async Task<Billing> GetAsync()
        {
            return await BillingRepository.GetAsync();
        }

        public async Task UpdateBillingAsync(Billing billing)
        {
            await BillingRepository.UpdateBillingAsync(billing);
        }
    }
}
