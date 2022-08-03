using ArlDrivingSchool.Core.Models.Setting;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Repositories.ObjectRelationalMapper;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Implementations
{
    public class BillingRepository : DapperRepository, IBillingRepository
    {
        public BillingRepository(IConfiguration configuration)
            :base(configuration)
        {

        }

        public async Task<Billing> GetAsync()
        {
            return await QueryFirstOrDefaultAsync<Billing>("[setting].[uspGetBillingSetting]", new { });
        }

        public async Task UpdateBillingAsync(Billing billing)
        {
            await ExecuteAsync("[setting].[uspUpdateBillingSetting]",
                new { 
                    billing.BillingId,
                    billing.TDCOnline,
                    billing.TDCClassroom,
                    billing.DEPOnline,
                    billing.DEPClassroom,
                    billing.PDCCarCombination,
                    billing.PDCCarManual,
                    billing.PDCCarMatic,
                    billing.PDCMotorCombination,
                    billing.PDCMotorManual,
                    billing.PDCMotorMatic,
                    billing.PDCTricycleCombination,
                    billing.PDCTricycleManual,
                    billing.PDCTricycleMatic,
                    billing.PDCPackage
                });
        }
    }
}
