using System;

namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class DateRangeRequestModel
    {
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
