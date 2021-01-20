﻿using ArlDrivingSchool.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArlDrivingSchoolApi.Controllers
{
    [Route("api/[controller]")]
    public class LookupController : ControllerBase
    {
        private ILookupsService LookupsService { get; set; }
        public LookupController(ILookupsService lookupsService)
        {
            LookupsService = lookupsService;
        }

        [HttpGet("restriction")]
        public async Task<IActionResult> GetAllRestrictionAsync()
        {
            var restrictions =  await LookupsService.GetAllRestrictionAsync();
            return Ok(restrictions);
        }

        [HttpGet("transmission")]
        public async Task<IActionResult> GetALLTransmissionAsync()
        {
            var trasmissions = await LookupsService.GetALLTransmissionAsync();
            return Ok(trasmissions);
        }
    }
}