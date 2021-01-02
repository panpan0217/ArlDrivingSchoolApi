using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.Models.Sessions
{
    public class PDCSessionOne
    {
        public int PDCSessionOneId { get; set; }
        public int PDCStudentId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Attended { get; set; }
    }
}
