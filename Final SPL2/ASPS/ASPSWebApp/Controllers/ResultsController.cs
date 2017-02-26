using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPSDataModel;

namespace ASPSWebApp.Controllers
{
    public class ResultsController : Controller
    {
        private ASPSEntities db = new ASPSEntities();

        // GET: Results
        public ActionResult Index()
        {
            var results = db.Results.Include(r => r.Course).Include(r => r.Student);
            return View(results.ToList());
        }

        // GET: Results/Details/5
        public ActionResult Details(string id)
        {
            //string email = ((Student)Session["Student"])
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // GET: Results/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.StudentEmail = new SelectList(db.Students, "StudentEmail", "StudentEmail");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentEmail,CourseID,CourseGrade,CoursePoint,CourseNumber")] Result result)
        {
            ResultRepository resultRepository = new ResultRepository();
            if (resultRepository.ValidResult(result.StudentEmail, result.CourseID))
            {
                Result currentResult = resultRepository.FindResult(result);
                if (currentResult == null)
                {
                    db.Results.Add(result);
                    db.SaveChanges();
                }
                else
                {
                    ViewBag.Message = "This course already added to student";
                }

                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", result.CourseID);
            ViewBag.StudentEmail = new SelectList(db.Students, "StudentEmail", "Name", result.StudentEmail);
            return View(result);
        }

        // GET: Results/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", result.CourseID);
            ViewBag.StudentEmail = new SelectList(db.Students, "StudentEmail", "Name", result.StudentEmail);
            return View(result);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentEmail,CourseID,CourseGrade,CoursePoint,CourseNumber")] Result result)
        {
            if (ModelState.IsValid)
            {
                db.Entry(result).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", result.CourseID);
            ViewBag.StudentEmail = new SelectList(db.Students, "StudentEmail", "Name", result.StudentEmail);
            return View(result);
        }

        // GET: Results/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Result result = db.Results.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Result result = db.Results.Find(id);
            db.Results.Remove(result);
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
