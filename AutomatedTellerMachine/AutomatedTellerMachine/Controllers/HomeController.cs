using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        //Get /Home/Index
        //[MyLoggingFilter]
        public ActionResult Index()
        {
            return View();
        }

        //Get /Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //Get /Home/Contact
        public ActionResult Contact()
        {
            ViewBag.TheMessage = "Have a troube? send us a message.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.TheMessage = "We got your message";

            return View();
        }

        public ActionResult Foo()
        {
            return View("About");
        }

        public ActionResult Serial(string letterCase)
        {
            var serial = "ASPNETMVC5ATM";
            if(letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            //return Content(serial);  
            //return new HttpStatusCodeResult(403);
            //return Json(new { name = "Serial", value = serial }, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
        }
    }
}