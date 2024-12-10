using System.Collections.Generic;

namespace ArlDrivingSchool.Core.Models.Payments
{
    public class PDCSubPayment
    {
        public int PDCSubPaymentId { get; set; }
        public int PDCPaymentId { get; set; }
        public int Payment { get; set; }
        public int PaymentModeId { get; set; }
        public string PaymentModeName { get; set; }
        public List<PDCSubPayment> PDCSubPayments { get; set; }
    }
}
