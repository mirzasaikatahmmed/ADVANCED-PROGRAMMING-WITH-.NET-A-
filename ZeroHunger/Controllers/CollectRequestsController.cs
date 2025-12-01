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
            return View();
        }
    }
}