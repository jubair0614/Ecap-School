using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPSDataModel;

namespace ASPSWebApp.Controllers
{
    public class AdminProfileController : Controller
    {
        ASPSEntities db = new ASPSEntities();

        // GET: AdminProfile
        public ActionResult Index()
        {
            return View();
        }

        // GET: Courses/Edit/5
        //[Authorize(Roles = "SystemAdministrator")]
        public ActionResult Edit()
        {
            string id = ((SystemAdministrator)Session["SystemAdministrator"]).SystemAdministratorEmail;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SystemAdministrator systemAdministrator = db.SystemAdministrators.Find(id);
            if (systemAdministrator == null)
            {
                return HttpNotFound();
            }
            return View(systemAdministrator);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "SystemAdministrator")]
        public ActionResult Edit(SystemAdministrator systemAdministrator)
        {
            systemAdministrator.SystemAdministratorEmail =
                ((SystemAdministrator) Session["SystemAdministrator"]).SystemAdministratorEmail;
            if (ModelState.IsValid)
            {
                db.Entry(systemAdministrator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(systemAdministrator);
        }
    }
}