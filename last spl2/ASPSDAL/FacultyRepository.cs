using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDAL
{
    public class FacultyRepository
    {
        ASPSEntities db = null;

        public FacultyRepository()
        {
            db = new ASPSEntities();
        }

        public bool AddFaculty(Faculty faculty)
        {
            db.Faculties.Add(faculty);
            return db.SaveChanges() > 0;
        }

        public bool EditFaculty(Faculty faculty)
        {
            db.Faculties.Attach(faculty);
            db.Entry(faculty).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool DeleteFaculty(Faculty faculty)
        {
            db.Faculties.Attach(faculty);
            db.Entry(faculty).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public List<Faculty> FacultiesList()
        {
            return db.Faculties.ToList();
        }

        public Faculty GetFacultyByEmail(string email)
        {
            return db.Faculties.FirstOrDefault(f => f.FacultyEmail == email);
        }

        public Faculty GetFacultyById(long id)
        {
            return db.Faculties.FirstOrDefault(f => f.FacultyID == id);
        }

        public bool ValidateFaculty(string email, string password)
        {
            return db.Faculties.Count(f => f.FacultyEmail == email && f.Password == password) > 0;
        }
    }
}
