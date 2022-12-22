using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hungers.DB;

namespace Zero_Hungers.Controllers
{
    public class LoginController : Controller
    {
        // GET: Users
        [HttpGet]
        public ActionResult Login()
        {
            return View();
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
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Login(string name, int password, string utype)
        {
            var db = new ZeroHungersdbEntities1();

            if (utype == "Admin")
            {

                var user = (from u in db.Admins
                            where u.Name == name && u.Password == password
                            select u).SingleOrDefault();
                if (user != null)
                {
                    Session["id"] = user.Id;
                    return RedirectToAction("Index","Admin");
                }
            }
            else if (utype == "Employee")
            {
                var user = (from u in db.Employees
                            where u.Name == name && u.Password == password
                            select u).SingleOrDefault();
                if (user != null)
                {
                    Session["id"] = user.Id;
                    return RedirectToAction("ShowAssignedTasks", "Employee");
                }
            }

            else if (utype == "Restaurant")
            {
                var user = (from u in db.Restaurants
                            where u.Name == name && u.Password == password
                            select u).SingleOrDefault();
                if (user != null)
                {
                    Session["id"] = user.Id;
                    return RedirectToAction("Restaurant","Restaurant");
                }
            }
            return View();
        }
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Restaurant()
        {
            var db = new ZeroHungersdbEntities1();
            var col = db.Collections.ToList();
            var collections = (from c in col
                               where c.RestaurantId == (int)Session["id"]
                               select c).ToList();
            return View(collections);
        }
        [HttpGet]
        public ActionResult CollectionRequest()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CollectionRequest(Collection c)
        {
            c.RestaurantId = (int)Session["id"];
            c.CollectionStatus = "Not Collected";
            var db = new ZeroHungersdbEntities1();
            db.Collections.Add(c);
            db.SaveChanges();
            return RedirectToAction("Restaurant");
        }
    }
}