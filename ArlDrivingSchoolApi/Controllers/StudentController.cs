using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.Models.Users;
using ArlDrivingSchool.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArlDrivingSchoolApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private IStudentService StudentService { get; }

        public StudentController(IStudentService studentService)
        {
            StudentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await StudentService.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetAllStudentWithDetailsAsync()
        {
            var studentsWithDetails = await StudentService.GetAllStudentWithDetailsAsync();
            return Ok(studentsWithDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel)
        {
            var firstName = requestModel.FirstName;

            await StudentService.CreateStudentWithDetailsAsync(requestModel);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudentDetailsRequestModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var hasUpdated = await StudentService.UpdateStudentByStudentIdAsync(request);
         
            if (hasUpdated)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudentAsync(int studentId)
        {
            if(studentId != 0)
            {
                await StudentService.DeleteStudentAsync(studentId);

            return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost("schedule")]
        public async Task<IActionResult> GetScheduleByDateAsync([FromBody] GetScheduleByDateRequestModel requestModel)
        {
            var studentSchedule = await StudentService.GetStudentScheduleByDateAsync(requestModel.Date, requestModel.Schedule, requestModel.SessionLocation);

            return Ok(studentSchedule);
        }

        [HttpPost("schedule/shuttle")]
        public async Task<IActionResult> GetShuttleScheduleByDateAsync([FromBody] GetShuttleScheduleByDateRequestModel requestModel)
        {
            var shuttleSchedule = await StudentService.GetShuttleScheduleByDateAsync(requestModel.Date, requestModel.Schedule);

            return Ok(shuttleSchedule);

        }

        [AllowAnonymous]
        [HttpGet("pdc/details")]
        public async Task<IActionResult> GetAllPDCStudentWithDetailsAsync()
        {
            var studentsWithDetails = await StudentService.GetAllPDCStudentWithDetailsAsync();
            return Ok(studentsWithDetails);
        }

        [AllowAnonymous]
        [HttpDelete("pdc/{id}")]
        public async Task<IActionResult> DeletePDCStudentAsync(int id)
        {
            if (id != 0)
            {
                await StudentService.DeletePDCStudentAsync(id);

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}