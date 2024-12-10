using ArlDrivingSchool.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArlDrivingSchoolApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private IPaymentService PaymentService { get; }

        public PaymentController(IPaymentService paymentService)
        {
            PaymentService = paymentService;
        }

        [HttpGet("monthly")]
        public async Task<ActionResult> GetMonthlyIncome()
        {
            var data = await PaymentService.GetMonthlyIncomeAsync();
            return Ok(data);
        }

        [HttpGet("weekly")]
        public async Task<ActionResult> GetWeeklyIncome()
        {
            var data = await PaymentService.GetWeeklyIncomeAsync();
            return Ok(data);
        }

        [HttpGet("daily")]
        public async Task<ActionResult> GetDailyIncome()
        {
            var data = await PaymentService.GetDailyIncomeAsync();
            return Ok(data);
        }

        [HttpDelete("subPayment/{subPaymentId}")]
        public async Task<ActionResult> DeleteSubPayment(int subPaymentId)
        {
            await PaymentService.DeleteSubPaymentAsync(subPaymentId);
            return Ok();
        }


        [HttpDelete("pdcSubPayment/{pdcSubPaymentId}")]
        public async Task<ActionResult> DeletePDCSubPayment(int pdcSubPaymentId)
        {
            await PaymentService.DeletePDCSubPaymentAsync(pdcSubPaymentId);
            return Ok();
        }
    }
}