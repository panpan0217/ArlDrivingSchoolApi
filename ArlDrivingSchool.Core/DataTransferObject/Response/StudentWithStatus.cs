using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class StudentWithStatus
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string FBContact { get; set; }

        public string Mobile { get; set; }
        public string StudentStatus { get; set; }
        public string TDCStatus { get; set; }
        public string ACESStatus { get; set; }
        public string Remarks { get; set; }
        public DateTime DateRegistered { get; set; }
        public bool Certified { get; set; }
        public DateTime DateCertified { get; set; }
        public string AuthenticatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ClassType { get; set; }
        public string SessionEmail { get; set; }
        public string DriveSafeStatus { get; set; }
        public string TextForm { get; set; }
        public string FullName => FirstName + ' ' + LastName;

        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public int EnrollmentModeId { get; set; }
        public string EnrollmentModeName { get; set; }
        public int UserId { get; set; }
        public int PDCStudentId { get; set; }
        public string Staff { get; set; }
        public DateTime? AcesSaveDate { get; set; }
    }
}
