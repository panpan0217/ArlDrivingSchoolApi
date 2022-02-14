using System;

namespace ArlDrivingSchool.Core.Models.Users
{
    public class ActivityLog
    {
        public int ActivityLogId { get; set; }
        public int ActivityLogTypeId { get; set; }
        public int UserId { get; set; }
        public DateTime LogDate { get; set; }
    }
}
