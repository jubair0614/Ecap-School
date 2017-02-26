using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ASPSDataModel;

namespace ASPSWebApp.Controllers
{
    public class SignUpController : Controller
    {
        public StudentRepository StudentRepository = new StudentRepository();
        public FacultyRepository FacultyRepository = new FacultyRepository();

        // Get/Student sign up
        public ActionResult StudentSignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StudentSignUp(Student student)
        {
            //if (!Regex.Match(student.StudentEmail,"@iit.du.ac.bd",RegexOptions.IgnoreCase).Success)
            //{
            //    ModelState.AddModelError("StudentEmail", "Email address not valid");
            //}
            if (ModelState.IsValid)
            {
                Student currentStudent = StudentRepository.FindStudent(student);
                if (currentStudent == null)
                {
                    StudentRepository.AddStudent(student);
                }
                else
                {
                    return RedirectToAction("StudentSignUp", "SignUp");
                }
            }
            return RedirectToAction("StudentSignIn", "SignIn");
        }

        public ActionResult FacultySignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FacultySignUp(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                Faculty currentFaculty = FacultyRepository.FindFaculty(faculty);
                if (currentFaculty == null)
                {
                    FacultyRepository.AddFaculty(faculty);
                }
                else
                {
                    return RedirectToAction("FacultySignUp", "SignUp");
                }
            }
            return RedirectToAction("FacultySignIn", "SignIn");
        }
    }
}