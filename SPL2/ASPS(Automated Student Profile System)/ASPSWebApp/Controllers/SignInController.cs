using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASPSDAL;

namespace ASPSWebApp.Controllers
{
    public class SignInController : Controller
    {
        private StudentRepository studentRepository = new StudentRepository();
        private FacultyRepository facultyRepository = new FacultyRepository();
        private AdminRepository adminRepository = new AdminRepository();

        //Get
        //[Authorize(Roles = "Student")]
        public ActionResult StudentSignIn()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "Student")]
        public ActionResult StudentSignIn(Student student)
        {
            if (studentRepository.ValidateStudent(student.StudentEmail, student.Password))
            {
                FormsAuthentication.SetAuthCookie(student.StudentEmail, false);
                Student currentstudent = studentRepository.GetStudentByEmail(student.StudentEmail);
                Session["Student"] = currentstudent;
                return RedirectToAction("Index", "StudentProfile");
            }
            else
            {
                ModelState.AddModelError("Input is not correct", "Incorrect");
                return RedirectToAction("StudentSignIn", "SignIn");
            }
        }

        //Get
        //[Authorize(Roles = "Faculty")]
        public ActionResult FacultySignIn()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "Faculty")]
        public ActionResult FacultySignIn(Faculty faculty)
        {
            if (facultyRepository.ValidateFaculty(faculty.FacultyEmail, faculty.Password))
            {
                FormsAuthentication.SetAuthCookie(faculty.FacultyEmail, false);
                Faculty currentFaculty = facultyRepository.GetFacultyByEmail(faculty.FacultyEmail);
                Session["Faculty"] = currentFaculty;
                return RedirectToAction("Index", "FacultyProfile");
            }
            else
            {
                ModelState.AddModelError("", "Incorrect");
                return RedirectToAction("FacultySignIn", "SignIn");
            }
        }

        //Get
        //[Authorize(Roles = "Admin")]
        public ActionResult AdminSignIn()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult AdminSignIn(Admin admin)
        {
            if (adminRepository.ValidateAdmin(admin.AdminEmail, admin.Password))
            {
                FormsAuthentication.SetAuthCookie(admin.AdminEmail, false);
                Admin currentAdmin = adminRepository.GetAdminByEmail(admin.AdminEmail);
                Session["Admin"] = currentAdmin;
                return RedirectToAction("Index", "AdminProfile");
            }
            else
            {
                ModelState.AddModelError("", "Incorrect");
                return RedirectToAction("AdminSignIn", "SignIn");
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}