using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hungers.DB;

namespace Zero_Hungers.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var db = new ZeroHungersdbEntities1();
            return View(db.Admins.SingleOrDefault());
        }

        [HttpGet]
        public ActionResult AddNewEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewEmployee(Employee cs)
        {
            var db = new ZeroHungersdbEntities1();
            db.Employees.Add(new Employee()
            {
                Name = cs.Name,
                Location = cs.Location,
                Password = cs.Password,
                CollectionRequest = 0,
                AdminId = 1,
            });

            var admin = db.Admins.SingleOrDefault();
            admin.CurrentEmployee = admin.CurrentEmployee + 1;


            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AddNewRestaurant()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewRestaurant(Restaurant rs)
        {
            var db = new ZeroHungersdbEntities1();
            db.Restaurants.Add(rs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult EmployeeList()
        {
            var db = new ZeroHungersdbEntities1();
            return View(db.Employees.ToList());
        }



        public ActionResult TaskAssign()
        {
            var db = new ZeroHungersdbEntities1();
            var Requests = (from r in db.Collections
                            where r.CollectionStatus == "Requested"
                            select r).ToList();
            return View(Requests);
        }



        public ActionResult AllTasks()
        {
            var db = new ZeroHungersdbEntities1();
            var Requests = db.Collections.ToList();
            return View(Requests);
        }



        [HttpGet]
        public ActionResult AssignEmployees(int id)
        {
            var db = new ZeroHungersdbEntities1();
            Session["CollectReqId"] = id;
            return View(db.Employees.ToList());
        }
        [HttpPost]
        public ActionResult AssignEmployees(int[] Employee)
        {
            var db = new ZeroHungersdbEntities1();
            var collectreqid = Int32.Parse(Session["collectreqid"].ToString());

            if (Employee.Length == 1)
            {
                var assigned = (from r in db.Collections
                                where r.Id == collectreqid
                                select r).SingleOrDefault();
                assigned.EmployeeId = Employee[0];
                assigned.CollectionStatus = "Assigned";
                db.SaveChanges();

                return RedirectToAction("AllTasks");
            }
            TempData["msg"] = "Can not assign more than 1 employee";
            return RedirectToAction("AllTasks");
        }
    }
}