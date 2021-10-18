﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class StudentFullDetailsRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string FBContact { get; set; }
        public string Mobile { get; set; }
        public int StudentStatusId { get; set; }
        public int TDCStatusId { get; set; }
        public int ACESStatusId { get; set; }
        public string Remarks { get; set; }
        public int TotalAmount { get; set; }
        public int Payment { get; set; }
        public int Balance { get; set; }
        public DateTime SessionOneDate { get; set; }
        public string SessionOneSchedule { get; set; }
        public bool SessionOneShuttle { get; set; }
        public string SessionOneLocation { get; set; }
        public int SessionOneBranchId { get; set; }
        public DateTime SessionTwoDate { get; set; }
        public string SessionTwoSchedule { get; set; }
        public bool SessionTwoShuttle { get; set; }
        public string SessionTwoLocation { get; set; }
        public int SessionTwoBranchId { get; set; }
        public DateTime SessionThreeDate { get; set; }
        public string SessionThreeSchedule { get; set; }
        public bool SessionThreeShuttle { get; set; }
        public string SessionThreeLocation { get; set; }
        public int SessionThreeBranchId { get; set; }
        public bool ForceCreate { get; set; }
        public string AuthenticatedBy { get; set; }
        public string ClassType { get; set; }
        public string SessionEmail { get; set; }
        public int DriveSafeStatusId { get; set; }
        public bool Certified { get; set; }
        public string TextForm { get; set; }
    }
}
