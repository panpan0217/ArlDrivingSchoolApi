using ArlDrivingSchool.Core.Models.Lookups;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Implementations
{
    public class ACESStatusService: IACESStatusService
    {
        private IACESStatusRepository ACESStatusRepository { get; set; }
        public ACESStatusService(IACESStatusRepository aCESStatusRepository)
        {
            ACESStatusRepository = aCESStatusRepository; 
        }

        public async Task<IEnumerable<ACESStatus>> GetAllAsync()
        {
            return await ACESStatusRepository.GetAllAsync();
        }
    }
}
