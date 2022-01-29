using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class RegisterRequestModel
    {
        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [Required]
        [StringLength(128)]
        public string Username { get; set; }

        [Required]
        [StringLength(128)]
        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }
        public string Birthday { get; set; }

        [Required]
        public int UserTypeId { get; set; }
        public string PhoneNumber { get; set; }

    }
}
