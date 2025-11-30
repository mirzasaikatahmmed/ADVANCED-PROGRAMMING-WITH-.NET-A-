using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZeroHunger.Controllers
{
    public class FoodItemsController : Controller
    {
        // GET: FoodItems
        public ActionResult Index()
        {
            return View();
        }
    }
}