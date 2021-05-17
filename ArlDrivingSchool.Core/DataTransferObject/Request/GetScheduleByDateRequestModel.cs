using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class GetScheduleByDateRequestModel
    {
        public DateTime Date { get; set; }
        public string Schedule { get; set; }
        public string SessionLocation { get; set; }
        public int BranchId { get; set; }

    }
}
