using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.Models.Users
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string FBContact { get; set; }
        public string Mobile { get; set; }
        public string AgentName { get; set; }
        public int StudentStatusId { get; set; }
        public int TDCStatusId { get; set; }
        public int ACESStatusId { get; set; }
        public string Remarks { get; set; }
        public DateTime DateRegistered { get; set; }
        public string AuthenticatedBy { get; set; }
        public string ClassType { get; set; }
        public string SessionEmail { get; set; }
        public int DriveSafeStatusId { get; set; }
        public string TextForm { get; set; }
        public int EnrollmentModeId { get; set; }
        public int? UserId { get; set; }
        public int? OfficeId { get; set; }
        public int? GenderId { get; set; }
        public DateTime? AcesSaveDate { get; set; }
        public string? OtherEnrollmentMode { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
