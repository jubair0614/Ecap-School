using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDataModel
{
    public class StudentRepository
    {
        ASPSEntities aspsEntities = null;

        public StudentRepository()
        {
            aspsEntities = new ASPSEntities();;
        }

        public bool AddStudent(Student student)
        {
            aspsEntities.Students.Add(student);
            return aspsEntities.SaveChanges() > 0;
        }

        public bool EditStudent(Student student)
        {
            aspsEntities.Students.Attach(student);
            aspsEntities.Entry(student).State = EntityState.Modified;
            return aspsEntities.SaveChanges() > 0;
        }

        public bool DeleteStudent(Student student)
        {
            aspsEntities.Students.Attach(student);
            aspsEntities.Entry(student).State = EntityState.Deleted;
            return aspsEntities.SaveChanges() > 0;
        }

        public List<Student> StudentsList()
        {
            return aspsEntities.Students.ToList();
        }

        public Student FindStudent(Student student)
        {
            return aspsEntities.Students.Find(student.StudentEmail);
        }

        public bool ValidStudent(string email, string password)
        {
            return aspsEntities.Students.Count(
                s => s.StudentEmail == email && s.Password == password) > 0;
        }

        public Student FindStudent(string studentEmail)
        {
            return aspsEntities.Students.Find(studentEmail);
        }
    }
}
