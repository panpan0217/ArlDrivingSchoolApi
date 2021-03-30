﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class StudentCertification
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public bool Certified { get; set; }
        public DateTime DateCertified { get; set; }

    }
}
