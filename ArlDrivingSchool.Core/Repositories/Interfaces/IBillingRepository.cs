using ArlDrivingSchool.Core.Models.Setting;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface IBillingRepository
    {
        Task<Billing> GetAsync();
        Task UpdateBillingAsync(Billing billing);
    }
}
