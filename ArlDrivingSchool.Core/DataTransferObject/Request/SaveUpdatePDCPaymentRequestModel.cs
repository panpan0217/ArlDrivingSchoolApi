using System.Collections.Generic;

namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class SaveUpdatePDCPaymentRequestModel
    {
        public int PDCPaymentId { get; set; }
        public int PDCStudentId { get; set; }
        public int TotalAmount { get; set; }
        public int Payment { get; set; }
        public int Balance { get; set; }
        public int PaymentModeId { get; set; }
        public List<SaveUpdatePDCSubPaymentRequestModel>? PDCSubPayments { get; set; }
    }

    public class SaveUpdatePDCSubPaymentRequestModel
    {
        public int PDCSubPaymentId { get; set; }
        public int PDCPaymentId { get; set; }
        public int Payment { get; set; }
        public int PaymentModeId { get; set; }
    }
}
