using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Attendance.Models;

namespace Attendance.Controllers
{


    public class EmployeeController : Controller
    {
        DateTime ComingTime = new DateTime(2019, 12, 30, 9, 0, 0);


        private ApplicationDbContext _context;
        //constructor
        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Employee

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Loginload()
        {
            return View();
        }
        public ActionResult Login([Bind(Exclude = "Id")]Login logIndata)
        {
            if (!ModelState.IsValid)
                return Content("notvalid");
            if (ModelState.IsValid)
            {

                var emp = _context.employees.Where(e => e.Email == logIndata.Name && e.Password == logIndata.Password).Single();
                if (emp == null)
                    return HttpNotFound();
                logIndata.EmployeeId = emp.Id;
                TempData["empattendance"] = emp;
                if (emp == null)
                {
                    return HttpNotFound();
                }
            }
            if (logIndata.id == 0)
            {
                _context.logIns.Add(logIndata);
                _context.SaveChanges();
            }
            return RedirectToAction("checkInOut", "Employee");
        }
        public ViewResult checkInOut()
        {
            return View();
        }
        public ActionResult checkIn()
        {
            if ((Employee)TempData["empattendance"] != null)
            {
                Attendances attendances = new Attendances();
                var attend = (Employee)TempData["empattendance"];
                attendances.EmployeeID = attend.Id;
                attendances.ComingTime = DateTime.Now;
                attendances.present = true;
                attendances.DateOfDay = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                TimeSpan interval =ComingTime - attendances.ComingTime;
                attendances.delay = (interval.Hours == 0 && interval.Minutes == 0) ? false : true;
                _context.attendances.Add(attendances);
                _context.SaveChanges();

            }
            return RedirectToAction("Loginload", "Employee");




        }
        public ActionResult CheckOut()
        {
            if ((Employee)TempData["empattendance"] != null)
            {
                var attend = (Employee)TempData["empattendance"];
                var empInDb = _context.attendances.FirstOrDefault(c => c.EmployeeID == attend.Id && c.DateOfDay.Day == DateTime.Now.Day
                                                                                   && c.DateOfDay.Month == DateTime.Now.Month
                                                                                    && c.DateOfDay.Year == DateTime.Now.Year);
                if (empInDb != null)
                {
                    empInDb.LeaveTime = DateTime.Now;
                }

            }
            _context.SaveChanges();
            return RedirectToAction("Loginload", "Employee");
        }
    }
}