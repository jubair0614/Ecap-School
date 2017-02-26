using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ASPSDataModel;

namespace ASPSWebApp.Controllers
{
    public class SignInController : Controller
    {
        private StudentRepository studentRepository = new StudentRepository();
        private FacultyRepository facultyRepository = new FacultyRepository();
        private AdminRepository systemAdminRepository = new AdminRepository();

        //Get
        public ActionResult StudentSignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentSignIn(Student student)
        {
            if (studentRepository.ValidStudent(student.StudentEmail, student.Password))
            {
                FormsAuthentication.SetAuthCookie(student.StudentEmail, false);
                Student currentstudent = studentRepository.FindStudent(student);
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
        public ActionResult FacultySignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FacultySignIn(Faculty faculty)
        {
            if (facultyRepository.ValidFaculty(faculty.FacultyEmail, faculty.Password))
            {
                FormsAuthentication.SetAuthCookie(faculty.FacultyEmail, false);
                Faculty currentFaculty = facultyRepository.FindFaculty(faculty);
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
        public ActionResult SystemAdminSignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SystemAdminSignIn(SystemAdministrator systemAdministrator)
        {
            if (systemAdminRepository.ValidSystemAdmin(systemAdministrator.SystemAdministratorEmail, systemAdministrator.Password))
            {
                FormsAuthentication.SetAuthCookie(systemAdministrator.SystemAdministratorEmail, false);
                SystemAdministrator currentSystemAdmin = systemAdminRepository.FindSystemAdmin(systemAdministrator);
                Session["SystemAdministrator"] = currentSystemAdmin;
                return RedirectToAction("Index", "AdminProfile");
            }
            else
            {
                ModelState.AddModelError("", "Incorrect");
                return RedirectToAction("SystemAdminSignIn", "SignIn");
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