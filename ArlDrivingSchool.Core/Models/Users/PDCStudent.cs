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
        public int B1TransmissionId { get; set; }
        public int B2TransmissionId { get; set; }
        public int ACourseId { get; set; }
        public int A1CourseId { get; set; }
        public int BCourseId { get; set; }
        public int B1CourseId { get; set; }
        public int B2CourseId { get; set; }
        public string Remarks { get; set; }
        public string StudentPermit { get; set; }
        public string AuthenticatedBy { get; set; }
        public int EnrollmentModeId { get; set; }
        public int? UserId { get; set; }
        public int? OfficeId { get; set; }
        public int? TransactionId { get; set; }
        public string? OtherEnrollmentMode { get; set; }
    }
}
