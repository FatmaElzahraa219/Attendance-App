using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attendance.Models
{
    public class Attendances
    {
        public int Id { get; set; }
        public Employee Employees { get; set; }

        public int EmployeeID { get; set; }
        public DateTime ComingTime { get; set; }
        [Display(Name = "Date")]
        public DateTime DateOfDay { get; set; }
        public bool present { get; set; }
        public bool delay { get; set; }

        public DateTime? LeaveTime { get; set; }
    }
}