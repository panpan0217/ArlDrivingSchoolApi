using ArlDrivingSchool.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        Task<int> CreateSessionOneAsync(int studentId, string schedule, bool shuttle, string sessionLocation);
        Task<int> CreateSessionTwoAsync(int studentId, string schedule, bool shuttle, string sessionLocation);
        Task<int> CreateSessionThreeAsync(int studentId, TimeSpan time, string branch);
    }
}
