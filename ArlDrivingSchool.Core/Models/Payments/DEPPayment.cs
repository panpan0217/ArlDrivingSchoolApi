using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.Models.Payments
{
    public class DEPPayment
    {
        public int DEPPaymentId { get; set; }
        public int DEPStudentId { get; set; }
        public int TotalAmount { get; set; }
        public int PaymentAmount { get; set; }
        public int Balance { get; set; }
    }
}
