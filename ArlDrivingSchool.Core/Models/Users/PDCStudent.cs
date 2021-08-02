using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.Models.Users
{
    public class PDCStudent
    {
        public int PDCStudentId { get; set; }
        public DateTime DateRegistered { get; set; }
        public string FullName { get; set; }
        public string FBContact { get; set; }
        public string Mobile { get; set; }
        public int ACESStatusId { get; set; }
        public string RestrictionId { get; set; }
        public int ATransmissionId { get; set; }
        public int A1TransmissionId { get; set; }
        public int BTransmissionId { get; set; }
        public string Remarks { get; set; }
        public string StudentPermit { get; set; }
        public string AuthenticatedBy { get; set; }
    }
}
