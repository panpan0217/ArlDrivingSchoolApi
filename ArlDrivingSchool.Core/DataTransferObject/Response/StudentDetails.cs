using ArlDrivingSchool.Core.Models.Payments;
using ArlDrivingSchool.Core.Models.Sessions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class StudentDetails
    {
        public virtual StudentWithStatus StudentWithStatus { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual SessionOne SessionOne { get; set; }
        public virtual SessionTwo SessionTwo { get; set; }
        public virtual SessionThree SessionThree { get; set; }
    }
}
