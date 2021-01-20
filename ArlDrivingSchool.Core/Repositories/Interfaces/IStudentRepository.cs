﻿
using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.DataTransferObject.Response;
using ArlDrivingSchool.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<IEnumerable<StudentDetails>> GetAllStudentWithDetailsAsync();

        Task<int> CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel);

        Task<bool> UpdateStudentByStudentIdAsync(Student student);

        Task<int> DeleteStudentAsync(int studentId);
        Task<IEnumerable<StudentSchedule>> GetStudentScheduleByDateAsync(DateTime date, string schedule, string sessionLocation);
        Task<IEnumerable<ShuttleSchedule>> GetShuttleScheduleByDateAsync(DateTime date, string schedule);

        Task<IEnumerable<PDCStudentDetails>> GetAllPDCStudentWithDetailsAsync();
        Task<int> DeletePDCStudentAsync(int pdcStudentId);
        Task<int> CreatePDCStudentWithDetailsAsync(PDCStudentFullDetailRequestModel requestModel);
        Task<bool> UpdatePDCStudentByStudentIdAsync(PDCStudent pdcStudent);

    }
}
