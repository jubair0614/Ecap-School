using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPSDAL;
using ASPSWebApp.BusinessCode;

namespace ASPSWebApp.Controllers
{
    public class FacultyProfileController : Controller
    {
        private FacultyRepository facultyRepository = new FacultyRepository();
        Faculty _faculty = (Faculty)System.Web.HttpContext.Current.Session["Faculty"];
        // GET: FacultyProfile
        [Authorize(Roles = "Faculty")]
        public ActionResult Index()
        {
            _faculty = facultyRepository.GetFacultyByEmail(_faculty.FacultyEmail);
            return View(_faculty);
        }

        // GET: FacultyProfile/Edit/5
        [Authorize(Roles = "Faculty")]
        public ActionResult Edit()
        {
            if (this._faculty.FacultyEmail == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty currentFaculty = facultyRepository.GetFacultyByEmail(_faculty.FacultyEmail);
            if (currentFaculty == null)
            {
                return HttpNotFound();
            }
            return View(_faculty);
        }

        // POST: FacultyProfile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Faculty")]
        public ActionResult Edit([Bind(Include = "FacultyID,FacultyEmail,Name,Password,Address,BloodGroup,Gender,Religion,MobileNumber,Designation")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                facultyRepository.EditFaculty(faculty);
                return RedirectToAction("Index");
            }
            return View(faculty);
        }

        [Authorize(Roles = "Faculty")]
        public ActionResult VisitStudentProfile()
        {
            return View(new StudentRepository().StudentsList());
        }

        //Get
        [Authorize(Roles = "Faculty")]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Faculty")]
        public ActionResult ChangePassword(string newPassword, string confirmPassword)
        {
            Password password = new Password();
            if (password.ComparePassword(newPassword, confirmPassword))
            {
                Faculty temp = facultyRepository.GetFacultyByEmail(_faculty.FacultyEmail);
                temp.Password = newPassword;
                facultyRepository.EditFaculty(temp);
            }
            return RedirectToAction("Index");
        }
    }
}