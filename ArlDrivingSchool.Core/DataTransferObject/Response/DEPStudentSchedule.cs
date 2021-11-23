using System;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class DEPStudentSchedule
    {
        public int DEPStudentId { get; set; }
        public string FullName { get; set; }
        public string FBContact { get; set; }
        public string Remarks { get; set; }
        public DateTime SessionDate { get; set; }
        public string Schedule { get; set; }
        public string SessionLocation { get; set; }
        public bool Attended { get; set; }
    }
}
