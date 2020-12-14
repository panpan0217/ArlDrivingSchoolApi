using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.Models.Users
{
    public class Access
    {
        public string Auth { get; set; }
        public string Salt { get; set; }
        public int UserId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsTempAuthActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
