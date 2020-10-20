using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class UpdateSessionAttendedRequestModel
    {
        public string Session { get; set; }
        public int StudentId { get; set; }
        public bool Attended { get; set; }

    }
}
