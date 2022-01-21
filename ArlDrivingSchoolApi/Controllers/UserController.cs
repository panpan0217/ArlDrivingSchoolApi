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
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Not Allowed!" });

            var user = new User
            {
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Username = requestModel.Username,
                Email = requestModel.Email,
                UserTypeId = requestModel.UserTypeId,
                Address = requestModel.Address,
                Birthday =requestModel.Birthday
            };

            await UserService.CreateAsync(user, requestModel.Password);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPut("profile")]
        public async Task<ActionResult> UpdateProfileLink([FromBody] SaveProfileLinkRequest requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Not Allowed!" });

            await UserService.SaveProfileLinkAync(requestModel.UserId, requestModel.ProfileLink);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var users = await UserService.GetAllUser();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id != 0)
            {
                await UserService.DeleteByIdAsync(id);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateUserRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Not Allowed!" });

            var user = new User
            {
                UserId = requestModel.UserId,
                FirstName = requestModel.FirstName,
                LastName = requestModel.LastName,
                Username = requestModel.Username,
                Email = requestModel.Email,
                UserTypeId = requestModel.UserTypeId,
                Address = requestModel.Address,
                Birthday = requestModel.Birthday
            };

            await UserService.UpdateAsync(user, requestModel.Password);

            return Ok();
        }
    }
}