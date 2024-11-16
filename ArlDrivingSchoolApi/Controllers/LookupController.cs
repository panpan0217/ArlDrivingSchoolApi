using ArlDrivingSchool.Core.Services.Interfaces;
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

        [HttpGet("driveSafeStatus")]
        public async Task<IActionResult> GetDriveSafeStatusAsync()
        {
            var driveSafeStatuses = await LookupsService.GetDriveSafeStatusAsync();

            return Ok(driveSafeStatuses);
        }


        [HttpGet("office")]
        public async Task<IActionResult> GetOfficeAsync()
        {
            var offices = await LookupsService.GetAllOfficeAsync();

            return Ok(offices);
        }

        [HttpGet("payment-mode")]
        public async Task<IActionResult> GetPaymentModeAsybc()
        {
            var paymentModes = await LookupsService.GetAllPaymentModeAsync();
            var dtos = paymentModes
            .Where(p => !p.PaymentModeName.Contains("remittance", StringComparison.OrdinalIgnoreCase))
            .ToList();
            return Ok(dtos);
        }
        [HttpGet("enrollment-mode")]
        public async Task<IActionResult> GetEnrollmentModeAsybc()
        {
            var enrollmentModes = await LookupsService.GetAllEnrollmentModeAsync();

            return Ok(enrollmentModes);
        }

        [HttpGet("transaction")]
        public async Task<IActionResult> GetAllTransactionAsync()
        {
            var transactions = await LookupsService.GetAllTransactionAsync();

            return Ok(transactions);
        }

        [HttpGet("course")]
        public async Task<IActionResult> GetAllCourseAsync()
        {
            var courses = await LookupsService.GetAllCourseAsync();

            return Ok(courses);
        }
    }
}
