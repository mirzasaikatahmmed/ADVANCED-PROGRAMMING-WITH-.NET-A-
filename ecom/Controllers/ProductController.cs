using ecom.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ecom.Controllers
{
    public class ProductController : Controller
    {
        ecomEntities db = new ecomEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories.ToList(), "Id", "Name");
            return View(new Product());
        }


        [HttpPost]
        public ActionResult Create(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            TempData["Msg"] = "Product " + p.Name + " Created";
            return RedirectToAction("List");
        }
        public ActionResult List(string search)
        {
            if (search != null)
            {
                var filter = (from s in db.Products
                              where s.Name.Contains(search)
                              select s).ToList();
                return View(filter);
            }
            var data = db.Products.ToList();
            return View(data);
        }
        public ActionResult Details(int id)
        {
            var data = db.Products.Find(id);
            return View(data);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var data = db.Products.Find(id);
            ViewBag.Categories = db.Categories.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Product p)
        {
            var dbObj = db.Products.Find(p.Id);
            db.Entry(dbObj).CurrentValues.SetValues(p);
            db.SaveChanges();
            TempData["Msg"] = "Data Updated";
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var data = db.Products.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            var dbObj = db.Products.Find(id);
            db.Products.Remove(dbObj);
            db.SaveChanges();
            TempData["Msg"] = "Product Deleted";
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Restock(int id, int amount)
        {
            var data = db.Products.Find(id);
            if (data != null)
            {
                data.Qty += amount;
                db.SaveChanges();
                TempData["Msg"] = "Product Restocked by " + amount;
            }

            var list = db.Products.ToList();
            return View("List", list);
        }


    }
}