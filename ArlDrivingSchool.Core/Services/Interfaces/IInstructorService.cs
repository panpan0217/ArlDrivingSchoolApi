using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Interfaces
{
    public interface IInstructorService
    {
        Task<IEnumerable<Instructor>> GetAllInstructorAsync();
        Task<Instructor> GetInstructorByIdAsync(int instructorId);
        Task<bool> UpdateInstructorByIdAsync(UpdateInstructorRequestModel instructor);
        Task<int> CreateInstructorAsync(Instructor instructor);
        Task<int> DeleteInstructorByIdAsync(int instructorId);
    }
}
