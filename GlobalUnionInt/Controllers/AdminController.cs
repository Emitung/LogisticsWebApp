using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GlobalUnionInt.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tracking()
        {
            return View();
        }

        public ActionResult ClientService()
        {
            return View();
        }

        public ActionResult DeliveryOrder()
        {
            return View();
        }
    }
}