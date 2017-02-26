using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPSDAL;

namespace ASPSWebApp.Controllers
{
    public class SearchController : Controller
    {
        ASPSEntities db = new ASPSEntities();
        // GET: Search
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string course, string semester, decimal courseNumber, decimal result)
        {
            var currentCourse = db.Courses.Where(c => (c.CourseCode == course) && (c.SemesterNumber == Int32.Parse(semester)));
            var currentRes = db.Results.Where(r => r.CourseNumber >= (decimal)courseNumber);
            var currentStudent = db.Students.Where(s => s.Result.Value >= (decimal)result);
            
            List<Student> list = new List<Student>();
            //list.Add();
            
            return View(list);
        }
    }
}