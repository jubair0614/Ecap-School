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
        ASPSEntities aspsEntities = null;

        public FacultyRepository()
        {
            aspsEntities = new ASPSEntities();
        }

        public bool AddFaculty(Faculty Faculty)
        {
            aspsEntities.Facultys.Add(Faculty);
            return aspsEntities.SaveChanges() > 0;
        }

        public bool EditFaculty(Faculty Faculty)
        {
            aspsEntities.Facultys.Attach(Faculty);
            aspsEntities.Entry(Faculty).State = System.Data.Entity.EntityState.Modified;
            return aspsEntities.SaveChanges() > 0;
        }

        public bool DeleteFaculty(Faculty Faculty)
        {
            aspsEntities.Facultys.Attach(Faculty);
            aspsEntities.Entry(Faculty).State = System.Data.Entity.EntityState.Deleted;
            return aspsEntities.SaveChanges() > 0;
        }

        public List<Faculty> FacultysList()
        {
            return aspsEntities.Facultys.ToList();
        } 
    }
}
