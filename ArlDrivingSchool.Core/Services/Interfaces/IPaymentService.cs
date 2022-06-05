using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<int> GetMonthlyIncomeAsync();
        Task<int> GetWeeklyIncomeAsync();
        Task<int> GetDailyIncomeAsync();
    }
}
