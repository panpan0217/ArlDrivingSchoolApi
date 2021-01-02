using ArlDrivingSchool.Core.Models.Payments;
using ArlDrivingSchool.Core.Models.Sessions;
using ArlDrivingSchool.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class PDCStudentDetails
    {
        public virtual PDCStudentWithStatus PDCStudentWithStatus { get; set; }
        public virtual PDCPayment PDCPayment { get; set; }
        public virtual PDCSessionOne PDCSessionOne { get; set; }
        public virtual PDCSessionTwo PDCSessionTwo { get; set; }
        public virtual PDCSessionThree PDCSessionThree { get; set; }
        public virtual PDCSessionFour PDCSessionFour { get; set; }
    }
}
