﻿using ArlDrivingSchool.Core.Models.Lookups;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArlDrivingSchool.Core.Services.Interfaces
{
    public interface ILookupsService 
    {
        Task<IEnumerable<Restriction>> GetAllRestrictionAsync();
        Task<IEnumerable<Transmission>> GetALLTransmissionAsync();
        Task<IEnumerable<DriveSafeStatus>> GetDriveSafeStatusAsync();
        Task<IEnumerable<Office>> GetAllOfficeAsync();
        Task<IEnumerable<PaymentMode>> GetAllPaymentModeAsync();
        Task<IEnumerable<EnrollmentMode>> GetAllEnrollmentModeAsync();
        Task<IEnumerable<Transaction>> GetAllTransactionAsync();
        Task<IEnumerable<Course>> GetAllCourseAsync();
        Task<IEnumerable<Gender>> GetAllGenderAsync();

    }
}
