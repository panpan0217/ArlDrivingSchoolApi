using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class UserAuthentication
    {
        public int UserId { get; set; }

        public int UserTypeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public string Sas { get; set; }
    }
}
