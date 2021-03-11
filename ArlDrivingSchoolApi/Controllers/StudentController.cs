﻿using System;
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


        [HttpPost]
        public async Task<IActionResult> CreateStudentWithDetailsAsync(StudentFullDetailsRequestModel requestModel)
        {

            var userId = Request.GetUserId(JWToken);

            await StudentService.CreateStudentWithDetailsAsync(requestModel, userId);
            return Ok();
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

        [HttpPost("pdc")]
        public async Task<IActionResult> CreatePDCStudentWithDetailsAsync(PDCStudentFullDetailRequestModel requestModel)
        {
            var userId = Request.GetUserId(JWToken);

            await StudentService.CreatePDCStudentWithDetailsAsync(requestModel, userId);
            return Ok();
        }

        [HttpGet("getPDCStudent/{pDCStudentId}")]
        public async Task<IActionResult> GetPDCStudentById(int pDCStudentId)
        {
            var student = await StudentService.GetPDCStudentByIdAsync(pDCStudentId);
            return Ok(student);
        }

    }
}