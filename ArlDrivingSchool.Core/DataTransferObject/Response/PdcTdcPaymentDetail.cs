using ArlDrivingSchool.Core.Models.Payments;
using System.Collections;
using System.Collections.Generic;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class PdcTdcPaymentDetail
    {
        public IEnumerable<PDCStudentDetails> PdcDetails { get; set; }
        public IEnumerable<TdcPayment> TdcDetails { get; set; }

    }
}
