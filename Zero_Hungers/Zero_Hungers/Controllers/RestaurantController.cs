using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zero_Hungers.DB;

namespace Zero_Hungers.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant

        public ActionResult Restaurant()
        {
            var db = new ZeroHungersdbEntities1();
            var col = db.Collections.ToList();
            var collections = (from c in col
                               where c.RestaurantId == (int)Session["Id"]
                               select c).ToList();
            return View(collections);
        }


        [HttpGet]
        public ActionResult PlaceNewRequest()
        {
            return View();
        }
      
            [HttpPost]
            public ActionResult PlaceNewRequest(Collection c)
            {
                c.RestaurantId = (int)Session["id"];
                c.CollectionStatus = "Requested";
                c.EmployeeId = null;
                c.CollectionDate = DateTime.Now;
                var db = new ZeroHungersdbEntities1();
                db.Collections.Add(c);
                db.SaveChanges();
                
            return RedirectToAction("Restaurant");
        }

        public ActionResult PendingCollectRequest()
        {
            var id = (int)Session["id"];
            var db = new ZeroHungersdbEntities1();
            var Requests = (from r in db.Collections
                            where r.RestaurantId == id && r.CollectionStatus == "Requested"
                            select r).ToList();
            return View(Requests);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new ZeroHungersdbEntities1();
            var ext = (from cs in db.Collections
                       where cs.Id == id
                       select cs).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Edit(Collection c)
        {
            var db = new ZeroHungersdbEntities1();
            var ext = (from cs in db.Collections
                       where cs.Id == c.Id
                       select cs).SingleOrDefault();
            ext.FoodName = c.FoodName;
            ext.FoodAmount = c.FoodAmount;
            ext.Id = ext.Id;
            db.SaveChanges();
            return RedirectToAction("PendingCollectRequest");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new ZeroHungersdbEntities1();
            var ext = (from cs in db.Collections
                       where cs.Id == id
                       select cs).SingleOrDefault();
            return View(ext);
        }
        [HttpPost]
        public ActionResult Delete(Collection c)
        {
            var db = new ZeroHungersdbEntities1();
            var ext = (from cs in db.Collections
                       where cs.Id == c.Id
                       select cs).SingleOrDefault();
            var CollId = ext.Id;
            db.Collections.Remove(ext);
            db.SaveChanges();

            var excol = (from cx in db.Collections
                         where cx.Id == CollId
                         select cx).FirstOrDefault();

            if (excol == null)
            {
                var exxt = (from css in db.Collections
                            where css.Id == CollId
                            select css).SingleOrDefault();
                db.Collections.Remove(exxt);
                db.SaveChanges();
            }
            return RedirectToAction("PendingCollectRequest");
        }

    }
}