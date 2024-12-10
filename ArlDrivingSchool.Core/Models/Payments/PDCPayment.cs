using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.Models.Payments
{
    public class PDCPayment
    {
        public int PDCPaymentId { get; set; }
        public int PDCStudentId { get; set; }
        public int TotalAmount { get; set; }
        public int PaymentAmount { get; set; }
        public int Balance { get; set; }
        public int PaymentModeId { get; set; }
        public string PaymentModeName { get; set; }
        public List<PDCSubPayment> PDCSubPayments { get; set; }
    }
}
