using ArlDrivingSchool.Core.Models.Payments;
using ArlDrivingSchool.Core.Models.Sessions;
using ArlDrivingSchool.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class DEPStudentDetails
    {
        public virtual DEPStudent DEPStudent { get; set; }
        public virtual DEPPayment DEPPayment { get; set; }
        public virtual DEPSession DEPSession { get; set; }
    }
}
