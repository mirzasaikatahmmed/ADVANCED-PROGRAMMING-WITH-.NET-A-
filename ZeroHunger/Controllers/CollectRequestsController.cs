using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZeroHunger.EF;

namespace ZeroHunger.Controllers
{
    public class CollectRequestsController : Controller
    {
        private ZeroHungerEntities db = new ZeroHungerEntities();
        // GET: CollectRequests
        public ActionResult Index()
        {
            // Load CollectRequests with Restaurant information
            var requests = db.CollectRequests
                             .Include(c => c.Restaurant)
                             .OrderByDescending(c => c.RequestedAt);

            if (!string.IsNullOrEmpty(Status))
            {
                requests = requests.Where(c => c.Status == Status)
                                   .OrderByDescending(c => c.RequestedAt);
            }

            // Optional: pass status filter to view
            ViewBag.CurrentStatusFilter = Status;

            return View(requests.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Include Restaurant; you can also Include Assignments, Distributions, FoodItems later
            var collectRequest = db.CollectRequests
                                   .Include(c => c.Restaurant)
                                   .FirstOrDefault(c => c.Id == id);

            if (collectRequest == null)
            {
                return HttpNotFound();
            }

            return View(collectRequest);
        }

        // GET: CollectRequests/Create
        public ActionResult Create()
        {
            // Dropdown for Restaurants
            ViewBag.RestaurantId = new SelectList(db.Restaurants.OrderBy(r => r.Name), "Id", "Name");
            return View();
        }

        // POST: CollectRequests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include =
            "RestaurantId,Title,Description,MaxPreserveUntil,EstimatedQuantity,PickupAddress")] CollectRequest collectRequest)
        {
            if (ModelState.IsValid)
            {
                // These are also defaulted in DB, but setting here is fine
                collectRequest.RequestedAt = DateTime.UtcNow;
                collectRequest.CreatedAt = DateTime.UtcNow;
                collectRequest.Status = "Pending";

                db.CollectRequests.Add(collectRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantId = new SelectList(db.Restaurants.OrderBy(r => r.Name), "Id", "Name", collectRequest.RestaurantId);
            return View(collectRequest);
        }

        // GET: CollectRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var collectRequest = db.CollectRequests.Find(id);
            if (collectRequest == null)
            {
                return HttpNotFound();
            }

            ViewBag.RestaurantId = new SelectList(db.Restaurants.OrderBy(r => r.Name), "Id", "Name", collectRequest.RestaurantId);
            return View(collectRequest);
        }

        // POST: CollectRequests/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include =
            "Id,RestaurantId,Title,Description,MaxPreserveUntil,RequestedAt,Status,EstimatedQuantity,PickupAddress,CreatedAt")]
            CollectRequest collectRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(collectRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestaurantId = new SelectList(db.Restaurants.OrderBy(r => r.Name), "Id", "Name", collectRequest.RestaurantId);
            return View(collectRequest);
        }

        // GET: CollectRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var collectRequest = db.CollectRequests
                                   .Include(c => c.Restaurant)
                                   .FirstOrDefault(c => c.Id == id);

            if (collectRequest == null)
            {
                return HttpNotFound();
            }

            return View(collectRequest);
        }

        // POST: CollectRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var collectRequest = db.CollectRequests.Find(id);
            if (collectRequest == null)
            {
                return HttpNotFound();
            }

            db.CollectRequests.Remove(collectRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ====== Extra actions for workflow (Accept / Complete / Cancel) ======

        // POST: CollectRequests/Accept/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Accept(int id)
        {
            var request = db.CollectRequests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }

            request.Status = "Accepted";
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: CollectRequests/Complete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Complete(int id)
        {
            var request = db.CollectRequests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }

            request.Status = "Completed";
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: CollectRequests/Cancel/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(int id)
        {
            var request = db.CollectRequests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }

            request.Status = "Cancelled";
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // Dispose
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