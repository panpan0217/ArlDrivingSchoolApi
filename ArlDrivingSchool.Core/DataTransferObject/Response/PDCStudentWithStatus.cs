﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class PDCStudentWithStatus
    {
        public int PDCStudentId { get; set; }
        public DateTime DateRegistered { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Location { get; set; }
        public string FBContact { get; set; }
        public string Mobile { get; set; }
        public string AgentName { get; set; }
        public string ACESStatus { get; set; }
        public string PaymentModeName { get; set; }
        public string RestrictionCode { get; set; }
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
        public bool Certified { get; set; }
        public DateTime DateCertified { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string AuthenticatedBy { get; set; }

        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public int EnrollmentModeId { get; set; }
        public string EnrollmentModeName { get; set; }
        public int UserId { get; set; }
        public string Staff { get; set; }
        public int TransactionId { get; set; }
        public string TransactionName { get; set; }
        public string OtherEnrollmentMode { get; set; }
        public int StudentId { get; set; }
        public int GenderId { get; set; }
    }

}
