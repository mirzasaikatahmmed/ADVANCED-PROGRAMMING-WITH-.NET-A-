using CustomValidationAndRegex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomValidationAndRegex.Helpers.Validators;

namespace CustomValidationAndRegex.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View(new Auth());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(Auth model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            TempData["Success"] = "Registration successful!";
            return RedirectToAction("Registration");
        }
    }
}