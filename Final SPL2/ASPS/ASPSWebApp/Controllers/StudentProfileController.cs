using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASPSDataModel;

namespace ASPSWebApp.Controllers
{
    public class StudentProfileController : Controller
    {
        private ASPSEntities db = new ASPSEntities();
        // GET: StudentProfile
        public ActionResult Index()
        {
            //Student student = ((Student)Session["Student"]);
            return View();
        }

        // GET: Students/Edit/5
        public ActionResult Edit()
        {
            string id = ((Student) Session["Student"]).StudentEmail;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentEmail,Name,Password,BloodGroup,Address,Religion,Gender,Roll,RegistrationNumber,Result,MobileNumber")] Student student)
        {
            student.StudentEmail = ((Student) Session["Student"]).StudentEmail;
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
          
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}