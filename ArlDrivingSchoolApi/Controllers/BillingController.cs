using ArlDrivingSchool.Core.Models.Setting;
using ArlDrivingSchool.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArlDrivingSchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private IBillingService BillingService { get; }

        public BillingController(IBillingService billingService)
        {
            BillingService = billingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBilling()
        {
            var billingSetting = await BillingService.GetAsync();
            return Ok(billingSetting);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBillingAsync(Billing billing)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await BillingService.UpdateBillingAsync(billing);
            return Ok();
        }
    }
}
