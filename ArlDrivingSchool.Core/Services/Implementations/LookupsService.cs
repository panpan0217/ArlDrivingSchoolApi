﻿using ArlDrivingSchool.Core.Models.Lookups;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Implementations
{
    public class LookupsService : ILookupsService
    {
        private ILookupsRepository LookupsRepository { get; set; }
        public LookupsService(ILookupsRepository lookupsRepository)
        {
            LookupsRepository = lookupsRepository;
        }

        public async Task<IEnumerable<Restriction>> GetAllRestrictionAsync()
        {
            return await LookupsRepository.GetAllRestrictionAsync();
        }

        public async Task<IEnumerable<Transmission>> GetALLTransmissionAsync()
        {
            return await LookupsRepository.GetALLTransmissionAsync();
        }
    }
}
