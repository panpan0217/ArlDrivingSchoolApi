using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class DEPStudentFullDetailsRequestModel
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
        public DateTime DateRegistered { get; set; }
        public int TotalAmount { get; set; }
        public int Payment { get; set; }
        public int Balance { get; set; }
        public DateTime SessionOneDate { get; set; }
        public string SessionOneSchedule { get; set; }
        public bool SessionOneShuttle { get; set; }
        public string SessionOneLocation { get; set; }
        public int SessionOneBranchId { get; set; }
        public bool ForceCreate { get; set; }
        public string ClassType { get; set; }
        public string SessionEmail { get; set; }
        public int DriveSafeStatusId { get; set; }
        public string TextForm { get; set; }
        public int EnrollmentModeId { get; set; }
        public int UserId { get; set; }
        public int OfficeId { get; set; }
        public int PaymentModeId { get; set; }
    }
}
