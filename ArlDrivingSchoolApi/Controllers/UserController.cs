﻿using System;
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
                Birthday =requestModel.Birthday,
                PhoneNumber =requestModel.PhoneNumber
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
                Birthday = requestModel.Birthday,
                PhoneNumber = requestModel.PhoneNumber
            };

            await UserService.UpdateAsync(user);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPut("updatePassword")]
        public async Task<ActionResult> UpdatePassword([FromBody] UpdateUserRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Not Allowed!" });

            var user = new User
            {
                UserId = requestModel.UserId,
            };

            await UserService.UpdatePasswordAsync(user, requestModel.Password);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdAsync(int userId)
        {
            if (userId != 0)
            {
                var user = await UserService.GetByIdAsync(userId);
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost("Log")]
        public async Task<ActionResult> LogUserActivity([FromBody] ActivityLogRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Not Allowed!" });
            var activityLog = new ActivityLog
            {
                ActivityLogTypeId = requestModel.ActivityLogTypeId,
                UserId = requestModel.UserId,
                StudentFullName = requestModel.StudentFullName,
                PageName = requestModel.PageName
            };
            await UserService.CreateLogActivityAsync(activityLog);
            return Ok();
        }


        [Authorize]
        [HttpPost("ActivityLogs")]
        public async Task<ActionResult> GetAllActivityLogs([FromBody] DateRangeRequestModel requestModel)
        {
            if (requestModel.UserId != 0)
            {
                var activityLogs = await UserService.GetAllActivityLogsByUserAsync(requestModel.UserId, requestModel.StartDate, requestModel.EndDate);
                return Ok(activityLogs);
            }
            else
            {
                var activityLogs = await UserService.GetAllActivityLogsAsync(requestModel.StartDate, requestModel.EndDate);
                return Ok(activityLogs);
            }

        }
    }
}