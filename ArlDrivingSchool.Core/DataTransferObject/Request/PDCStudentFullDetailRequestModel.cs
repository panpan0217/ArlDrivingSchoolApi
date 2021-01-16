﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class PDCStudentFullDetailRequestModel
    {
        public string FullName { get; set; }
        public string FBContact { get; set; }
        public string Mobile { get; set; }
        public int ACESStatusId { get; set; }
        public string Remarks { get; set; }
        public int TotalAmount { get; set; }
        public int Payment { get; set; }
        public int Balance { get; set; }
        public DateTime SessionOneDate { get; set; }
        public DateTime SessionOneStartTime { get; set; }
        public DateTime SessionOneEndTime { get; set; }
        public bool SessionOneAttended { get; set; }
        public DateTime SessionTwoDate { get; set; }
        public DateTime SessionTwoStartTime { get; set; }
        public DateTime SessionTwoEndTime { get; set; }
        public bool SessionTwoAttended { get; set; }
        public DateTime SessionThreeDate { get; set; }
        public DateTime SessionThreeStartTime { get; set; }
        public DateTime SessionThreeEndTime { get; set; }
        public bool SessionThreeAttended { get; set; }
        public DateTime SessionFourDate { get; set; }
        public DateTime SessionFourStartTime { get; set; }
        public DateTime SessionFourEndTime { get; set; }
        public bool SessionFourAttended { get; set; }
    }
}