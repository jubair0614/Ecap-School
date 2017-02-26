using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPSWebApp.Controllers
{
    public class FacultyProfileController : Controller
    {
        // GET: FacultyProfile
        public ActionResult Index()
        {
            return View();
        }

        /*public ActionResult Recommend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Recommend()
        {
            return View();
        }*/

        public ActionResult VisitStudent()
        {
            return View();
        }
    }
}