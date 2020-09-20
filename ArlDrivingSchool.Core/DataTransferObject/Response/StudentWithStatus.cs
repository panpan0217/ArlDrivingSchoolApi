using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class StudentWithStatus
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string FBContact { get; set; }

        public string Mobile { get; set; }
        public string StudentStatus { get; set; }
        public string TDCStatus { get; set; }
        public string ACESStatus { get; set; }
        public string Remarks { get; set; }
        public string Package { get; set; }
        public DateTime DateRegistered { get; set; }

    }
}
