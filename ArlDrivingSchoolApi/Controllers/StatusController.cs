using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArlDrivingSchool.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArlDrivingSchoolApi.Controllers
{

    [Route("api/[controller]")]
    public class StatusController : Controller
    {
        private IStudentStatusService StudentStatusService { get; set; }
        private IACESStatusService ACESStatusService { get; set; }
        private ITDCStatusService TDCStatusService { get; set; }

        public StatusController(IStudentStatusService studentStatusService, 
                                IACESStatusService aCESStatusService,
                                ITDCStatusService tDCStatusService)
        {
            StudentStatusService = studentStatusService;
            ACESStatusService = aCESStatusService;
            TDCStatusService = tDCStatusService;
        }

        [HttpGet("student")]
        public async Task<IActionResult> GetStudent()
        {
            var studentStatus = await StudentStatusService.GetAllAsync();
            return Ok(studentStatus);
        }

        [HttpGet("aces")]
        public async Task<IActionResult> GetACES()
        {
            var studentStatus = await ACESStatusService.GetAllAsync();
            return Ok(studentStatus);
        }

        [HttpGet("tdc")]
        public async Task<IActionResult> GetTDC()
        {
            var studentStatus = await TDCStatusService.GetAllAsync();
            return Ok(studentStatus);
        }
    }
}