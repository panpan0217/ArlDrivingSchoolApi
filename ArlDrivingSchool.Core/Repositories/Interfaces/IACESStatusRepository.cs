using ArlDrivingSchool.Core.Models.Lookups;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface IACESStatusRepository
    {
        Task<IEnumerable<ACESStatus>> GetAllAsync();
    }
}
