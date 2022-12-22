using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hungers.DB;

namespace Zero_Hungers.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult ShowAssignedTasks()
        {
            var id = (int)Session["id"];
            var db = new ZeroHungersdbEntities1();
            var tasks = (from t in db.Collections
                         where t.EmployeeId == id
                         select t.Id);
            List<Collection> collectList = new List<Collection>();

            foreach (var item in db.Collections)
            {
                foreach (var i in tasks)
                {
                    if (item.Id == i && item.CollectionStatus == "Completed")
                    {
                        collectList.Add(item);
                    }
                }
            }

            return View(collectList);

        }

        public ActionResult ShowPendingTasks()
        {
            var id = (int)Session["id"];
            var db = new ZeroHungersdbEntities1();
            var tasks = (from t in db.Collections
                         where t.EmployeeId == id
                         select t.Id);
            List<Collection> collectList = new List<Collection>();

            foreach (var item in db.Collections)
            {
                foreach (var i in tasks)
                {
                    if (item.Id == i && item.CollectionStatus == "Assigned")
                    {
                        collectList.Add(item);
                    }
                }
            }

            return View(collectList);
        }

        [HttpGet]
        public ActionResult Complete(int id)
        {
            var db = new ZeroHungersdbEntities1();
            var ext = (from cs in db.Collections
                       where cs.Id == id
                       select cs).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Complete(Collection c)
        {
            var db = new ZeroHungersdbEntities1();
            var ext = (from cs in db.Collections
                       where cs.Id == c.Id
                       select cs).SingleOrDefault();
            ext.CollectionStatus = "Completed";
            ext.RestaurantId = ext.RestaurantId;
            ext.EmployeeId = ext.EmployeeId;
            db.SaveChanges();

            var id = (int)Session["id"];

            var ex = (from cs in db.Employees
                      where cs.Id == id
                      select cs).SingleOrDefault();
            ex.CollectionRequest = ex.CollectionRequest + 1;
            db.SaveChanges();

            var admin = db.Admins.SingleOrDefault();
            admin.TotalCompletedRequest = admin.TotalCompletedRequest + 1;
            db.SaveChanges();

            return RedirectToAction("ShowAssignedTasks");
        }
    }
}