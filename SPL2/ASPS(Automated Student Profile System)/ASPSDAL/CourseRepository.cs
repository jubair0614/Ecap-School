using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDAL
{
    public class CourseRepository
    {
        ASPSEntities db = null;

        public CourseRepository()
        {
            db = new ASPSEntities();
        }

        public bool AddCourse(Course course)
        {
            db.Courses.Add(course);
            return db.SaveChanges() > 0;
        }

        public bool EditCourse(Course course)
        {
            db.Courses.Attach(course);
            db.Entry(course).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool DeleteCourse(Course course)
        {
            db.Courses.Attach(course);
            db.Entry(course).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public List<Course> CoursesList()
        {
            return db.Courses.ToList();
        }

        public Course GetCourseByCode(string code)
        {
            return db.Courses.FirstOrDefault(c => c.CourseCode == code);
        }
    }
}
