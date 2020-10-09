﻿using ArlDrivingSchool.Core.DataTransferObject.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<int> CreatePaymentAsync(int studentId, int totalAmount, int payment, int balance);
        Task<bool> UpdatePaymentByStudentIdAsync(UpdatePaymentRequestModel payment);
    }
}
