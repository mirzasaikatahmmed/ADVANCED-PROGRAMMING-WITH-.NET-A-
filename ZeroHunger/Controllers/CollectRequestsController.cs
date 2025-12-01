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
    public class CollectRequestsController : Controller
    {
        private ZeroHungerEntities db = new ZeroHungerEntities();

        public ActionResult Index()
        {
            var requests = db.CollectRequests
                             .Include(c => c.Restaurant)
                             .OrderByDescending(c => c.RequestedAt)
                             .ToList();
            return View(requests);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var collectRequest = db.CollectRequests
                                   .Include(c => c.Restaurant)
                                   .FirstOrDefault(c => c.Id == id);

            if (collectRequest == null)
                return HttpNotFound();

            return View(collectRequest);
        }
        public ActionResult Create()
        {
            PopulateRestaurantsDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantId,Title,Description,MaxPreserveUntil,EstimatedQuantity,PickupAddress")] EF.CollectRequest collectRequest)
        {
            if (ModelState.IsValid)
            {
                collectRequest.Status = "Pending";
                collectRequest.RequestedAt = DateTime.UtcNow;
                collectRequest.CreateAt = DateTime.UtcNow;

                db.CollectRequests.Add(collectRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateRestaurantsDropDownList(collectRequest.RestaurantId);
            return View(collectRequest);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var collectRequest = db.CollectRequests.Find(id);
            if (collectRequest == null)
                return HttpNotFound();

            PopulateRestaurantsDropDownList(collectRequest.RestaurantId);
            return View(collectRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RestaurantId,Title,Description,MaxPreserveUntil,Status,EstimatedQuantity,PickupAddress")] EF.CollectRequest collectRequest)
        {
            if (ModelState.IsValid)
            {
                var existing = db.CollectRequests
                                 .AsNoTracking()
                                 .FirstOrDefault(c => c.Id == collectRequest.Id);

                if (existing == null)
                    return HttpNotFound();

                collectRequest.RequestedAt = existing.RequestedAt;
                collectRequest.CreateAt = existing.CreateAt;

                db.Entry(collectRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateRestaurantsDropDownList(collectRequest.RestaurantId);
            return View(collectRequest);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var collectRequest = db.CollectRequests
                                   .Include(c => c.Restaurant)
                                   .FirstOrDefault(c => c.Id == id);

            if (collectRequest == null)
                return HttpNotFound();

            return View(collectRequest);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var collectRequest = db.CollectRequests.Find(id);
            if (collectRequest == null)
                return HttpNotFound();

            db.CollectRequests.Remove(collectRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateRestaurantsDropDownList(object selectedRestaurant = null)
        {
            var restaurants = db.Restaurants
                                .OrderBy(r => r.Name)
                                .ToList();
            ViewBag.RestaurantId = new SelectList(restaurants, "Id", "Name", selectedRestaurant);
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