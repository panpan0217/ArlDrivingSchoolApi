using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArlDrivingSchool.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArlDrivingSchoolApi.Controllers
{
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
    }
}