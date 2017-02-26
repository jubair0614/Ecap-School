using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPSDAL;

namespace ASPSWebApp.Controllers
{
    public class CourseRecommendationsController : Controller
    {
        private ASPSEntities db = new ASPSEntities();

        // GET: CourseRecommendations
        [Authorize(Roles = "Faculty")]
        public ActionResult Index()
        {
            var courseRecommendations = db.CourseRecommendations.Include(c => c.Course).Include(c => c.Faculty).Include(c => c.Student);
            return View(courseRecommendations.ToList());
        }

        // GET: CourseRecommendations/Details/5
        [Authorize(Roles = "Faculty")]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRecommendation courseRecommendation = db.CourseRecommendations.Find(id);
            if (courseRecommendation == null)
            {
                return HttpNotFound();
            }
            return View(courseRecommendation);
        }

        // GET: CourseRecommendations/Create
        [Authorize(Roles = "Faculty")]
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode");
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyEmail");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentEmail");
            return View();
        }

        // POST: CourseRecommendations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Faculty")]
        public ActionResult Create([Bind(Include = "ContentID,FacultyID,StudentID,CourseID,CourseRating")] CourseRecommendation courseRecommendation)
        {
            if (ModelState.IsValid)
            {
                db.CourseRecommendations.Add(courseRecommendation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", courseRecommendation.CourseID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyEmail", courseRecommendation.FacultyID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentEmail", courseRecommendation.StudentID);
            return View(courseRecommendation);
        }

        // GET: CourseRecommendations/Edit/5
        [Authorize(Roles = "Faculty")]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRecommendation courseRecommendation = db.CourseRecommendations.Find(id);
            if (courseRecommendation == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", courseRecommendation.CourseID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyEmail", courseRecommendation.FacultyID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentEmail", courseRecommendation.StudentID);
            return View(courseRecommendation);
        }

        // POST: CourseRecommendations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Faculty")]
        public ActionResult Edit([Bind(Include = "ContentID,FacultyID,StudentID,CourseID,CourseRating")] CourseRecommendation courseRecommendation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseRecommendation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseCode", courseRecommendation.CourseID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyEmail", courseRecommendation.FacultyID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentEmail", courseRecommendation.StudentID);
            return View(courseRecommendation);
        }

        // GET: CourseRecommendations/Delete/5
        [Authorize(Roles = "Faculty")]
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseRecommendation courseRecommendation = db.CourseRecommendations.Find(id);
            if (courseRecommendation == null)
            {
                return HttpNotFound();
            }
            return View(courseRecommendation);
        }

        // POST: CourseRecommendations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Faculty")]
        public ActionResult DeleteConfirmed(long id)
        {
            CourseRecommendation courseRecommendation = db.CourseRecommendations.Find(id);
            db.CourseRecommendations.Remove(courseRecommendation);
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
