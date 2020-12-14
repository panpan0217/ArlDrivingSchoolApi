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
    public class UserController : ControllerBase
    {
        private IUserService UserService { get; }
        private IStudentService StudentService { get; }

        public UserController(IUserService userService, IStudentService studentService)
        {
            UserService = userService;
            StudentService = studentService;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] LoginRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Not Allowed!" });

            var user = await UserService.AuthenticateUserAsync(requestModel.Username, requestModel.Password);

            if (user == null)
                return Ok(new { error = "Email and Password is incorrect." });


            return Ok(user);
        }

    }
}