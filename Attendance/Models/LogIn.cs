using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Attendance.Models
{
    public class Login
    {

        public int id { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Name { get; set; }
        public string Password { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}