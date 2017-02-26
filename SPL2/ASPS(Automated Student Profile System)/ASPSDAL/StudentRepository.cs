using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDAL
{
    public class StudentRepository
    {
        ASPSEntities db = null;

        public StudentRepository()
        {
            db = new ASPSEntities();
        }

        public bool AddStudent(Student student)
        {
            db.Students.Add(student);
            return db.SaveChanges() > 0;
        }

        public bool EditStudent(Student student)
        {
            db.Students.Attach(student);
            db.Entry(student).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool DeleteStudent(Student student)
        {
            db.Students.Attach(student);
            db.Entry(student).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public List<Student> StudentsList()
        {
            return db.Students.ToList();
        } 

        public Student GetStudentByEmail(string email)
        {
            return db.Students.FirstOrDefault(s => s.StudentEmail == email);
        }

        public Student GetStudentById(long id)
        {
            return db.Students.FirstOrDefault(s => s.StudentID == id);
        }

        public bool ValidateStudent(string email, string password)
        {
            return db.Students.Count(s => s.StudentEmail == email && s.Password == password) > 0;
        }
    }
}
