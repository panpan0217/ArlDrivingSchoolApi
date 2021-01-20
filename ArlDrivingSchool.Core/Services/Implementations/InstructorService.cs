using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.Models.Users;
using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Implementations
{
    public class InstructorService: IInstructorService
    {
        private IInstructorRepository InstructorRepository { get; set; }

        public InstructorService(IInstructorRepository instructorRepository)
        {
            InstructorRepository = instructorRepository;
        }

        public async Task<IEnumerable<Instructor>> GetAllInstructorAsync()
        {
            return await InstructorRepository.GetAllInstructorAsync();
        }

        public async Task<bool> UpdateInstructorByIdAsync(UpdateInstructorRequestModel instructor)
        {
            return await InstructorRepository.UpdateInstructorByIdAsync(instructor);
        }

        public async Task<int> CreateInstructorAsync(Instructor instructor)
        {
            return await InstructorRepository.CreateInstructorAsync(instructor);
        }

        public async Task<int> DeleteInstructorByIdAsync(int instructorId)
        {
            return await InstructorRepository.DeleteInstructorByIdAsync(instructorId);
        }
    }
}
