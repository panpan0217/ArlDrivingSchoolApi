using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface IInstructorRepository
    {
        Task<IEnumerable<Instructor>> GetAllInstructorAsync();
        Task<bool> UpdateInstructorByIdAsync(UpdateInstructorRequestModel instructor);
        Task<int> CreateInstructorAsync(Instructor instructor);
        Task<int> DeleteInstructorByIdAsync(int instructorId);
    }
}
