using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string FBContact { get; set; }
   
        public string Mobile { get; set; }
        public int StudentStatusId { get; set; }
        public int TDCStatusId { get; set; }
        public int ACESStatusId { get; set; }
        public string Remarks { get; set; }
        public string Package { get; set; }
        public DateTime DateRegistered { get; set; }


    }
}
