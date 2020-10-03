using ArlDrivingSchool.Core.Models.Lookups;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Interfaces
{
    public interface IACESStatusService
    {
        Task<IEnumerable<ACESStatus>> GetAllAsync();
    }
}
