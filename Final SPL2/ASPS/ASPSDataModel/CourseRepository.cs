using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDataModel
{
    public class CourseRepository
    {
        ASPSEntities aspsEntities = null;

        public CourseRepository()
        {
            aspsEntities = new ASPSEntities();
        }

        public bool AddCourse(Course course)
        {
            aspsEntities.Courses.Add(course);
            return aspsEntities.SaveChanges() > 0;
        }

        public bool EditCourse(Course course)
        {
            aspsEntities.Courses.Attach(course);
            aspsEntities.Entry(course).State = EntityState.Modified;
            return aspsEntities.SaveChanges() > 0;
        }

        public bool DeleteCourse(Course course)
        {
            aspsEntities.Courses.Attach(course);
            aspsEntities.Entry(course).State = EntityState.Deleted;
            return aspsEntities.SaveChanges() > 0;
        }

        public List<Course> CoursesList()
        {
            return aspsEntities.Courses.ToList();
        } 
    }
}
