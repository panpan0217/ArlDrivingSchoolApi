using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class GetShuttleScheduleByDateRequestModel
    {
        public DateTime Date { get; set; }
        public string Schedule { get; set; }
    }
}
