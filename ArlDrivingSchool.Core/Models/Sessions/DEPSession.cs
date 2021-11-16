using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.Models.Sessions
{
    public class DEPSession
    {
        public int DEPSessionId { get; set; }
        public int DEPStudentId { get; set; }
        public DateTime Date { get; set; }
        public string Schedule { get; set; }
        public string SessionLocation { get; set; }
        public bool Attended { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
