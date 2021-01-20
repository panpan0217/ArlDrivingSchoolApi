using ArlDrivingSchool.Core.Models.Lookups;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface ILookupsRepository
    {
        Task<IEnumerable<Restriction>> GetAllRestrictionAsync();
        Task<IEnumerable<Transmission>> GetALLTransmissionAsync();
    }
}
