using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Attendance.Migrations;
using System.Web.Mvc;
using Attendance.Models;

namespace Attendance.Controllers
{
    public class AdminController : Controller
    {
     
        private ApplicationDbContext _context;
        //constructor
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public ActionResult New()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New([Bind(Exclude = "Id")]Employee employees)
        {
             if (!ModelState.IsValid)
             {
                 return HttpNotFound();
             }
            if(employees.Id ==0)
                _context.employees.Add(employees);
            

            else
            {
                var EmployeeInDb = _context.employees.Single(c => c.Id == employees.Id);


                EmployeeInDb.Name = employees.Name;
                EmployeeInDb.Email = employees.Email;
                EmployeeInDb.Password = employees.Password;
                EmployeeInDb.ConfirmPassword =employees.ConfirmPassword;
                EmployeeInDb.salary =employees.salary;
                EmployeeInDb.joiningDate = employees.joiningDate;
                EmployeeInDb.BirthDate = employees.BirthDate;


            }
            _context.SaveChanges();
            return RedirectToAction("New", "Admin");
        }
        [Authorize(Roles = "Admin")]
        
        public ActionResult EmployeeReport()
        {
            var Month = DateTime.Now.Month;
            List<EmployeeAttendance> empWithDate = new List<EmployeeAttendance>();
            var attendGroupbyId = (from s in _context.attendances.Include(a=>a.Employees)
               .Where(a => a.DateOfDay.Month == Month)
                       group s by s.EmployeeID).ToList();

            if (attendGroupbyId.Count == 0)
                return HttpNotFound();
           
            foreach (var idgroup in attendGroupbyId)
            {
                var absent = 0;
                var alldays = DateTime.Now.Day;
                var comingdays = idgroup.Count();
                var workdays = (alldays / 7);

                if (alldays >28)
                workdays = workdays + 1;
                for (int i=1;i<=workdays ;i++)
                {
                    if (comingdays >= 5 && alldays >= 7)
                    {
                        comingdays -= 5;
                        alldays-= 7;
                    }
                    else if(alldays >=7)
                    {
                        alldays -= 2;

                    }

                    
                }


                absent = alldays - comingdays;
                
                var count = 0;

                var name = "";
                foreach ( Attendances s in idgroup)
                {
                    if (s.delay == true)
                        count += 1;
                    
                      name=  _context.employees.Where(a => a.Id == s.EmployeeID).Select(a => a.Name).Single();

                }
               var listitem= new EmployeeAttendance()
                {
                    id = (int)idgroup.Key,
                    Present = absent,
                    delay = count,
                    employeeName = name

                };
                empWithDate.Add(listitem);
                            }
            return View(empWithDate);
        }
    }
}
