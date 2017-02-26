using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASPSDAL;
using ASPSWebApp.BusinessCode;

namespace ASPSWebApp.Controllers
{
    public class StudentProfileController : Controller
    {
        private StudentRepository studentRepository = new StudentRepository();
        private Student _student = (Student) System.Web.HttpContext.Current.Session["Student"];

        // GET: StudentProfile
        [Authorize(Roles = "Student")]
        public ActionResult Index()
        {    
            _student = studentRepository.GetStudentByEmail(_student.StudentEmail);
            return View(_student);
        }

        // GET: StudentProfile/Edit/5
        [Authorize(Roles = "Student")]
        public ActionResult Edit()
        {
            if (this._student.StudentEmail == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student currentStudent = studentRepository.GetStudentByEmail(_student.StudentEmail);
            if (_student == null)
            {
                return HttpNotFound();
            }
            return View(_student);
        }

        // POST: StudentProfile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Student")]
        public ActionResult Edit([Bind(Include = "StudentID,StudentEmail,Name,Password,BloodGroup,Address,Religion,Gender,Roll,RegistrationNumber,Result,MobileNumber")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.EditStudent(student);
                return RedirectToAction("Index");
            }
            return View(_student);
        }
        //Get
        [Authorize(Roles = "Student")]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Student")]
        public ActionResult ChangePassword(string newPassword, string confirmPassword)
        {
            Password password = new Password();
            if (password.ComparePassword(newPassword, confirmPassword))
            {
                Student temp = studentRepository.GetStudentByEmail(_student.StudentEmail);
                temp.Password = newPassword;
                studentRepository.EditStudent(temp);
            }
            return RedirectToAction("Index");
        }
    }
}
