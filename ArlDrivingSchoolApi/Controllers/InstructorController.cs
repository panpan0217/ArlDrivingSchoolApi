using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.Models.Users;
using ArlDrivingSchool.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArlDrivingSchoolApi.Controllers
{
    [Route("api/[controller]")]
    public class InstructorController : ControllerBase
    {
        private IInstructorService InstructorService { get; set; }

        public InstructorController(IInstructorService instructorService)
        {
            InstructorService = instructorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInstructorAsync()
        {
            var restrictions = await InstructorService.GetAllInstructorAsync();
            return Ok(restrictions);
        }

        [HttpGet("getInstructor/{instructorId}")]
        public async Task<IActionResult> GetInstructorById(int instructorId)
        {
            var instructor = await InstructorService.GetInstructorByIdAsync(instructorId);
            return Ok(instructor);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Instructor request)
        {
            if (request == null)
                return NotFound();

            await InstructorService.CreateInstructorAsync(request);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateInstructorRequestModel requestModel)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest();

            var hasUpdated = await InstructorService.UpdateInstructorByIdAsync(requestModel);

            if (hasUpdated)
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
          
            if (id != 0)
            {
                await InstructorService.DeleteInstructorByIdAsync(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
