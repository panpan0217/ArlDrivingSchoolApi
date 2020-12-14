using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.Models.Users
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
    }
}
