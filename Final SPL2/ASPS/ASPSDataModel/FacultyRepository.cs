using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDataModel
{
    public class FacultyRepository
    {
        ASPSEntities aspsEntities = null;

        public FacultyRepository()
        {
            aspsEntities = new ASPSEntities();
        }

        public bool AddFaculty(Faculty faculty)
        {
            aspsEntities.Faculties.Add(faculty);
            return aspsEntities.SaveChanges() > 0;
        }

        public bool EditFaculty(Faculty faculty)
        {
            aspsEntities.Faculties.Attach(faculty);
            aspsEntities.Entry(faculty).State = EntityState.Modified;
            return aspsEntities.SaveChanges() > 0;
        }

        public bool DeleteFaculty(Faculty faculty)
        {
            aspsEntities.Faculties.Attach(faculty);
            aspsEntities.Entry(faculty).State = EntityState.Deleted;
            return aspsEntities.SaveChanges() > 0;
        }

        public List<Faculty> FacultiesList()
        {
            return aspsEntities.Faculties.ToList();
        }

        public Faculty FindFaculty(Faculty faculty)
        {
            return aspsEntities.Faculties.Find(faculty.FacultyEmail);
        }

        public Faculty FindFaculty(string facultyEmail)
        {
            return aspsEntities.Faculties.Find(facultyEmail);
        }

        public bool ValidFaculty(string email, string password)
        {
            return aspsEntities.Faculties.Count(f => f.FacultyEmail == email && f.Password == password) > 0;
        }
    }
}
