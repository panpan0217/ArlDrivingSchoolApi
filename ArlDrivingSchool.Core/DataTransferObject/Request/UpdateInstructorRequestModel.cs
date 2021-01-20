using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class UpdateInstructorRequestModel
    {
        public int InstructorId { get; set; }
        public string FullName { get; set; }
        public string Status { get; set; }
    }
}
