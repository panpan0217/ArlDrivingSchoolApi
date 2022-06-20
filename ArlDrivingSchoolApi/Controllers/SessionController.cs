using ArlDrivingSchool.Core.DataTransferObject.Request;
using ArlDrivingSchool.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArlDrivingSchoolApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private ISessionService SessionService { get; set; }
        public SessionController(ISessionService sessionService)
        {
            SessionService = sessionService;
        }

        [HttpGet("getAllPDCSession")]
        public async Task<IActionResult> GetAllPDCSession()
        {
            var pDCSession = await SessionService.GetAllPDCSessionAsync();
            return Ok(pDCSession);
        }

        [HttpGet("getPDCSession/{instructorId}")]
        public async Task<IActionResult> GetAllPDCSession(int instructorId)
        {
            var pDCSessions = await SessionService.GetAllPDCSessionByInstructorIdAsync(instructorId);
            return Ok(pDCSessions);
        }

        [HttpPut("attended")]
        public async Task<IActionResult> UpdateSessionAttended([FromBody] UpdateSessionAttendedRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            bool hasUpdated;

            if (requestModel.Session.Contains("1"))
            {
                hasUpdated = await SessionService.UpdateSessionOneAttendedByStudentIdAsync(requestModel.StudentId, 
                                                                                        requestModel.Attended);
            }
            else if(requestModel.Session.Contains("2"))
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

        [HttpPost]
        public async Task<IActionResult> CreatePDCSession(PDCSessionRequestModel requestModel)
        {
            await SessionService.CreatePDCSession(
                requestModel.PDCStudentId,
                requestModel.Date,
                requestModel.StartTime,
                requestModel.EndTime,
                requestModel.InstructorId,
                requestModel.Attended,
                requestModel.Remarks
                );
            return Ok();
        }

        [HttpPut("pdcSession")]
        public async Task<IActionResult> UpdatePDCSession(PDCSessionRequestModel requestModel)
        {
            await SessionService.UpdatePDCSession(requestModel);
            return Ok();
        }

        [HttpDelete("pdcSession/{pDCSessionId}")]
        public async Task<IActionResult> DeletePDCSession(int pDCSessionId)
        {
            await SessionService.DeletePDCSession(pDCSessionId);
            return Ok();
        }

        [HttpPut("dep/attended")]
        public async Task<IActionResult> UpdateDEPSessionAttended([FromBody] UpdateSessionAttendedRequestModel requestModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var hasUpdated = await SessionService.UpdateDEPSessionOneAttendedByStudentIdAsync(requestModel.StudentId,
                                                                                        requestModel.Attended);
            if (hasUpdated)
                return Ok();
            else
                return NotFound();

        }
    }
}