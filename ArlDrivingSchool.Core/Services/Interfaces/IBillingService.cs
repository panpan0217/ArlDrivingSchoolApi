using ArlDrivingSchool.Core.Models.Setting;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Interfaces
{
    public interface IBillingService
    {
        Task<Billing> GetAsync();
        Task UpdateBillingAsync(Billing billing);
    }
}
