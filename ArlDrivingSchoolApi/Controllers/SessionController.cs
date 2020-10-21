﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArlDrivingSchoolApi.Controllers
{
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private ISessionService SessionService { get; set; }
        public SessionController(ISessionService sessionService)
        {
            SessionService = sessionService;
        }

        [HttpPut("attended")]
        public async Task<IActionResult> UpdateSessionAttended([FromBody] UpdateSessionAttendedRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool hasUpdated;

            if (requestModel.Session.Contains("One"))
            {
                hasUpdated = await SessionService.UpdateSessionOneAttendedByStudentIdAsync(requestModel.StudentId, 
                                                                                        requestModel.Attended);
            }
            else if(requestModel.Session.Contains("Two"))
            {
                hasUpdated = await SessionService.UpdateSessionTwoAttendedByStudentIdAsync(requestModel.StudentId,
                                                                                             requestModel.Attended);
            }
            else
            {
                hasUpdated = await SessionService.UpdateSessionThreeAttendedByStudentIdAsync(requestModel.StudentId,
                                                                                           requestModel.Attended);
            }

            if (hasUpdated)
                return Ok();
            else
                return NotFound();

        }
    }
}