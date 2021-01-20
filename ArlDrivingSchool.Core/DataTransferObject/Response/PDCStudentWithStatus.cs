using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class PDCStudentWithStatus
    {
        public int PDCStudentId { get; set; }
        public DateTime DateRegistered { get; set; }
        public string FullName { get; set; }
        public string FBContact { get; set; }
        public string Mobile { get; set; }
        public string ACESStatus { get; set; }
        public string RestrictionCode { get; set; }
        public string TransmissionName { get; set; }

        public string Remarks { get; set; }
    }

}
