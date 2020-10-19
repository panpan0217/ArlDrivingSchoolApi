using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class StudentSchedule
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FBContact { get; set; }
        public DateTime SessionDate { get; set; }
        public string Schedule { get; set; }
        public string Session { get; set; }
        public string SessionLocation { get; set; }
        public int TDCStatusId { get; set; }
        public string StatusName { get; set; }

    }
}
