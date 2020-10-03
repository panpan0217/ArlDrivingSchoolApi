using ArlDrivingSchool.Core.Models.Lookups;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Implementations
{
    public class TDCStatusService : ITDCStatusService
    {
        private ITDCStatusRepository TDCStatusRepository { get; set; }

        public TDCStatusService(ITDCStatusRepository tDCStatusRepository)
        {
            TDCStatusRepository = tDCStatusRepository;
        }

        public async Task<IEnumerable<TDCStatus>> GetAllAsync()
        {
            return await TDCStatusRepository.GetAllAsync();
        }
    }
}
