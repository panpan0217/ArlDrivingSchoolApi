using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.Models.Users;
using ArlDrivingSchool.Core.Services.Interfaces;
using ArlDrivingSchool.Utility.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEO.Utility.Extensions;

namespace ArlDrivingSchoolApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private IStudentService StudentService { get; }
        private JWToken JWToken { get; }

        public StudentController(IStudentService studentService, JWToken jwToken)
        {
            StudentService = studentService;
            JWToken = jwToken;
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

        [HttpGet("getStudentBy/{studentId}")]
        public async Task<IActionResult> GetStudentById(int studentId)
        {
            var student = await StudentService.GetStudentByIdAsync(studentId);
            return Ok(student);
        }

        [HttpPost("details/dateRange")]
        public async Task<IActionResult> GetStudentWithDetailsByDateRangeAsync([FromBody] DateRangeRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var studentsWithDetails = await StudentService.GetStudentWithDetailsByDateRangeAsync(requestModel.StartDate, requestModel.EndDate);
            return Ok(studentsWithDetails);
        }

        [HttpPost("detailsPDC/dateRange")]
        public async Task<IActionResult> GetPDCStudentWithDetailsByDateRangeAsync([FromBody] DateRangeRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var studentsWithDetails = await StudentService.GetPDCStudentWithDetailsByDateRangeAsync(requestModel.StartDate, requestModel.EndDate);
            return Ok(studentsWithDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel)
        {

            var userId = Request.GetUserId(JWToken);
            var students = await StudentService.GetAllStudentWithDetailsByFullNameAsync(requestModel.FirstName, requestModel.LastName);
            if (requestModel.ForceCreate)
            {
                var id = await StudentService.CreateStudentWithDetailsAsync(requestModel, userId);
                return Ok(id);
            }
            else
            {
                if (students.Count() > 0)
                {
                    return Ok(students);
                }
            }

            // If no same record student
            var studentId = await StudentService.CreateStudentWithDetailsAsync(requestModel, userId);
            return Ok(studentId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudentDetailsRequestModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = Request.GetUserId(JWToken);

            var hasUpdated = await StudentService.UpdateStudentByStudentIdAsync(request, userId);

            if (hasUpdated)
                return Ok();
            else
                return NotFound();
        }

        [HttpPut("pdc")]
        public async Task<IActionResult> UpdatePDC([FromBody] PDCStudentFullDetailRequestModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = Request.GetUserId(JWToken);
            var hasUpdated = await StudentService.UpdatePDCStudentByStudentIdAsync(request, userId);

            if (hasUpdated)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudentAsync(int studentId)
        {
            if (studentId != 0)
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
            if (!ModelState.IsValid)
                return BadRequest();

            var studentSchedule = await StudentService.GetStudentScheduleByDateAsync(requestModel.Date, requestModel.Schedule,
                requestModel.SessionLocation, requestModel.BranchId);

            return Ok(studentSchedule);
        }

        [HttpPost("schedule/shuttle")]
        public async Task<IActionResult> GetShuttleScheduleByDateAsync([FromBody] GetShuttleScheduleByDateRequestModel requestModel)
        {
            var shuttleSchedule = await StudentService.GetShuttleScheduleByDateAsync(requestModel.Date, requestModel.Schedule, requestModel.BranchId);

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

        [HttpPost("pdc")]
        public async Task<IActionResult> CreatePDCStudentWithDetailsAsync(PDCStudentFullDetailRequestModel requestModel)
        {
            var userId = Request.GetUserId(JWToken);
            var students = await StudentService.GetAllPDCStudentWithDetailsByFullNameAsync(requestModel.FullName);
            if (requestModel.ForceCreate)
            {
                await StudentService.CreatePDCStudentWithDetailsAsync(requestModel, userId);
                return Ok();
            }
            else
            {
                if (students.Count() > 0)
                {
                    return Ok(students);
                }
            }

            // If no same record student
            await StudentService.CreatePDCStudentWithDetailsAsync(requestModel, userId);
            return Ok();
        }

        [HttpGet("getPDCStudent/{pDCStudentId}")]
        public async Task<IActionResult> GetPDCStudentById(int pDCStudentId)
        {
            var student = await StudentService.GetPDCStudentByIdAsync(pDCStudentId);
            return Ok(student);
        }


        [HttpPost("params")]
        public async Task<IActionResult> GetStudentByParams([FromBody] GetCertifiedRequestModel requestModel)
        {
            var students = await StudentService.GetStudentByParams(requestModel.Certificated, requestModel.StartDate, requestModel.EndDate);
            return Ok(students);
        }
        [HttpPost("pdc/params")]
        public async Task<IActionResult> GetPDCStudentByParams([FromBody] GetCertifiedRequestModel requestModel)
        {
            var students = await StudentService.GetPDCStudentByParams(requestModel.Certificated, requestModel.StartDate, requestModel.EndDate);
            return Ok(students);
        }
        [HttpPost("dep/params")]
        public async Task<IActionResult> GetDEPStudentByParams([FromBody] GetCertifiedRequestModel requestModel)
        {
            var students = await StudentService.GetDEPStudentByParams(requestModel.Certificated, requestModel.StartDate, requestModel.EndDate);
            return Ok(students);
        }

        [HttpPut("certification")]
        public async Task<IActionResult> UpdateStudentCertificationByIdsAsync([FromBody] string studentIds)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await StudentService.UpdateStudentCertificationByIdsAsync(studentIds);
            return Ok();
        }

        [HttpPut("pdc/certification")]
        public async Task<IActionResult> UpdatePDCStudentCertificationByIdsAsync([FromBody] string studentIds)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await StudentService.UpdatePDCStudentCertificationByIdsAsync(studentIds);
            return Ok();
        }

        [HttpPut("dep/certification")]
        public async Task<IActionResult> UpdateDEPStudentCertificationByIdsAsync([FromBody] string studentIds)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await StudentService.UpdateDEPStudentCertificationByIdsAsync(studentIds);
            return Ok();
        }

        [HttpPut("uncertified")]
        public async Task<IActionResult> UpdateUncertifiedStudentByIdAsync([FromBody] int studentIds)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await StudentService.UpdateUncertifiedStudentByIdAsync(studentIds);
            return Ok();
        }
        [HttpPut("pdc/uncertified")]
        public async Task<IActionResult> UpdateUncertifiedPDCStudentByIdAsync([FromBody] int studentIds)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await StudentService.UpdateUncertifiedPDCStudentByIdAsync(studentIds);
            return Ok();
        }
        [HttpPut("dep/uncertified")]
        public async Task<IActionResult> UpdateUncertifiedDEPStudentByIdAsync([FromBody] int studentIds)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await StudentService.UpdateUncertifiedDEPStudentByIdAsync(studentIds);
            return Ok();
        }

        //DEP
        [HttpPost("dep")]
        public async Task<IActionResult> CreateDEPStudentWithDetailsAsync(DEPStudentFullDetailsRequestModel requestModel)
        {

            var userId = Request.GetUserId(JWToken);
            // If no same record student
            await StudentService.CreateDEPStudentWithDetailsAsync(requestModel, userId);
            return Ok();
        }

        [HttpPut("dep")]
        public async Task<IActionResult> UpdateDEPStudent([FromBody] DEPStudentFullDetailsRequestModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var userId = Request.GetUserId(JWToken);

            var hasUpdated = await StudentService.UpdateStudentByStudentIdAsync(request, userId);

            if (hasUpdated)
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("dep/daterange")]
        public async Task<IActionResult> GetAllDEPStudentWithDetailsAsync([FromBody] DateRangeRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var students = await StudentService.GetAllDEPStudentWithDetailsAsync(requestModel.StartDate, requestModel.EndDate);
            return Ok(students);
        }


        [HttpPost("dep/schedule")]
        public async Task<IActionResult> GetDEPScheduleByDateAsync([FromBody] GetScheduleByDateRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var studentSchedule = await StudentService.GetDEPStudentScheduleByDateAsync(requestModel.Date, requestModel.Schedule,
                requestModel.SessionLocation, requestModel.BranchId);

            return Ok(studentSchedule);
        }

        [HttpGet("getDEPStudentBy/{studentId}")]
        public async Task<IActionResult> GetDEPStudentById(int studentId)
        {
            var student = await StudentService.GetDEPStudentByIdAsync(studentId);
            return Ok(student);
        }

        [HttpPost("total")]
        public async Task<IActionResult> GetTotalStudentAndCertificationAsync([FromBody] DateRangeRequestModel requestModel )
        {
            var total = await StudentService.GetTotalStudentAndCertificationAsync(requestModel.StartDate, requestModel.EndDate);
            return Ok(total);
        }

    }
}