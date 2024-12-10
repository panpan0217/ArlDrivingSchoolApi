using System.Collections.Generic;

namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class SaveUpdatePaymentRequestModel
    {
        public int PaymentId { get; set; }
        public int StudentId { get; set; }
        public int TotalAmount { get; set; }
        public int Payment { get; set; }
        public int Balance { get; set; }
        public int PaymentModeId { get; set; }
        public List<SaveUpdateSubPaymentRequestModel>? SubPayments { get; set; }
    }

    public class SaveUpdateSubPaymentRequestModel
    {
        public int SubPaymentId { get; set; }
        public int PaymentId { get; set; }
        public int Payment { get; set; }
        public int PaymentModeId { get; set; }
    }
}
