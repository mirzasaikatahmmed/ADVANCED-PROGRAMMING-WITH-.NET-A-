using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMS.EF;
using UMS.DTOs;

namespace UMS.Controllers
{
    public class DepartmentController : Controller
    {
        private Mid_Lab_Final_TaskEntities db = new Mid_Lab_Final_TaskEntities();

        // GET: Department
        public ActionResult Index()
        {
            var data = db.Departments
                         .Select(d => new DepartmentDTO
                         {
                             Id = d.Id,
                             DepartmentName = d.DepartmentName
                         }).ToList();

            return View(data);
        }

        public ActionResult Details(int id)
        {
            var dept = db.Departments.Find(id);
            if (dept == null) return HttpNotFound();

            var dto = new DepartmentDTO
            {
                Id = dept.Id,
                DepartmentName = dept.DepartmentName
            };

            return View(dto);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentDTO model)
        {
            if (ModelState.IsValid)
            {
                var dept = new Department
                {
                    DepartmentName = model.DepartmentName
                };

                db.Departments.Add(dept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var dept = db.Departments.Find(id);
            if (dept == null) return HttpNotFound();

            var dto = new DepartmentDTO
            {
                Id = dept.Id,
                DepartmentName = dept.DepartmentName
            };

            return View(dto);
        }

        [HttpPost]
        public ActionResult Edit(DepartmentDTO model)
        {
            if (ModelState.IsValid)
            {
                var dept = db.Departments.Find(model.Id);
                if (dept == null) return HttpNotFound();

                dept.DepartmentName = model.DepartmentName;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var dept = db.Departments.Find(id);
            if (dept == null) return HttpNotFound();

            var dto = new DepartmentDTO
            {
                Id = dept.Id,
                DepartmentName = dept.DepartmentName
            };

            return View(dto);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var dept = db.Departments.Find(id);
            if (dept == null) return HttpNotFound();

            db.Departments.Remove(dept);
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
