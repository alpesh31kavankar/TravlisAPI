using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class LoginCode
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }

        public string BirthDate { get; set; }

        public string Address { get; set; }

        public string Photo { get; set; }
        public string EmailStatus { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
    public class Loginc
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public string Role { get; set; }
    }
    public class OtpNo
    {
        public string Mobile { get; set; }
        public int Id { get; set; }

    }
}