﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class PDCSession
    {
        public int PDCSessionId { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PDCStudentId { get; set; }
        public int InstructorId { get; set; }
        public bool Attended { get; set; }
	}
}
