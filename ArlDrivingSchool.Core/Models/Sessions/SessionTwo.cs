using System;

namespace ArlDrivingSchool.Core.Models.Sessions
{
    public class SessionTwo
    {
        public int SessionTwoId { get; set; }
        public int StudentId { get; set; }
        public DateTime SessionDate { get; set; }
        public string Schedule { get; set; }
        public bool Shuttle { get; set; }
        public string SessionLocation { get; set; }
        public bool Attended { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
    }
}
