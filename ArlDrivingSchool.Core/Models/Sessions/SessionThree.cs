using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.Models.Sessions
{
    public class SessionThree
    {
        public int SessionThreeId { get; set; }
        public int StudentId { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan Time { get; set; }
        public string Branch { get; set; }

    }
}
