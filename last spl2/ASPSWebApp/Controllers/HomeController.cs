using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPSWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "ASPS - Description";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "ASPS - Contact";

            return View();
        }
    }
}