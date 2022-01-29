using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class UpdateUserRequestModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Birthday { get; set; }
        public int UserTypeId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
