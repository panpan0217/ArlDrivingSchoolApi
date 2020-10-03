﻿using ArlDrivingSchool.Core.Repositories.Interfaces;
using ArlDrivingSchool.Core.Repositories.ObjectRelationalMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Repositories.Implementations
{
    public class PaymentRepository : DapperRepository, IPaymentRepository
    {
        private IConfiguration Configuration { get; }

        public PaymentRepository(IConfiguration configuration)
            : base(configuration)
        {
            Configuration = configuration;
        }

        public async Task<int> CreatePaymentAsync(int studentId, int totalAmount, int payment, int balance)
        {
            using var connection = new SqlConnection(Configuration.GetConnectionString("ArlDrivingSchoolContext"));
            var paymentId = await connection.ExecuteScalarAsync<int>("[payments].[uspInsertPayment]",
                                                                    new
                                                                    {
                                                                        StudentId = studentId,
                                                                        TotalAmount = totalAmount,
                                                                        Payment = payment,
                                                                        Balance = balance
                                                                    }
                                                                    , commandType: CommandType.StoredProcedure);
            return paymentId;
        }
    }
}