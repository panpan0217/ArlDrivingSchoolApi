﻿using ArlDrivingSchool.Core.Models.Payments;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class UpdatePaymentRequestModel
    {
        public int StudentId { get; set; }
        public int TotalAmount { get; set; }
        public int Payment { get; set; }
        public int Balance { get; set; }
        public int PaymentModeId { get; set; }
        public List<PDCSubPayment> PDCSubPayments { get; set; }
    }
}
