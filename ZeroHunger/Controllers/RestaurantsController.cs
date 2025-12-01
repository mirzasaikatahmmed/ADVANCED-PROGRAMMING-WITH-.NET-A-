using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;
using ZeroHunger.Models;

namespace ZeroHunger.Controllers
{
    public class RestaurantsController : Controller
    {
        private ZeroHungerEntities db = new ZeroHungerEntities();

        public ActionResult Index()
        {
            var restaurants = db.Restaurants
                                .OrderByDescending(r => r.CreateAt)
                                .ToList();
            return View(restaurants);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
                return HttpNotFound();

            return View(restaurant);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,ContactPerson,ContactPhone,Address,Email")] EF.Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                restaurant.CreateAt = DateTime.UtcNow;
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
                return HttpNotFound();

            return View(restaurant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ContactPerson,ContactPhone,Address,Email")] EF.Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                var existing = db.Restaurants.AsNoTracking().FirstOrDefault(r => r.Id == restaurant.Id);
                if (existing == null)
                    return HttpNotFound();

                restaurant.CreateAt = existing.CreateAt;

                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
                return HttpNotFound();

            return View(restaurant);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
                return HttpNotFound();

            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}