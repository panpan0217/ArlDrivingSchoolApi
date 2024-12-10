namespace ArlDrivingSchool.Core.Models.Payments
{
    public class SubPayment
    {
        public int SubPaymentId { get; set; }
        public int PaymentId { get; set; }
        public int Payment { get; set; }
        public int PaymentModeId { get; set; }
        public string PaymentModeName { get; set; }
    }
}
