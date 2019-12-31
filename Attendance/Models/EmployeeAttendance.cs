using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance.Models
{
    public class EmployeeAttendance
    {
        public int id { get; set; }
        public string employeeName { get; set; }
        public int Present { get; set; }
        public int delay { get; set; }
       // public DateTime Date { get; set; }
    }
}