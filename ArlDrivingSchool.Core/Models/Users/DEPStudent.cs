using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.Models.Users
{
    public class DEPStudent
    {
        public int DEPStudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string FBContact { get; set; }
        public string Mobile { get; set; }
        public string LicenseNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Remarks { get; set; }
        public bool ForceCreate { get; set; }
        public string ClassType { get; set; }
        public string SessionEmail { get; set; }
        public int DriveSafeStatusId { get; set; }
        public string DriveSafeStatus { get; set; }
        public string TextForm { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime DateCertified { get; set; }

        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public int EnrollmentModeId { get; set; }
        public string EnrollmentModeName { get; set; }
        public int UserId { get; set; }
        public string Staff { get; set; }
        public string OtherEnrollmentMode { get; set; }
    }
}
