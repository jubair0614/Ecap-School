using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDataModel
{
    public class ResultRepository
    {
        ASPSEntities aspsEntities = null;

        public ResultRepository()
        {
            aspsEntities = new ASPSEntities();
        }

        public bool AddResult(Result result)
        {
            aspsEntities.Results.Add(result);
            return aspsEntities.SaveChanges() > 0;
        }

        public bool EditResult(Result result)
        {
            aspsEntities.Results.Attach(result);
            aspsEntities.Entry(result).State = EntityState.Modified;
            return aspsEntities.SaveChanges() > 0;
        }

        public bool DeleteResult(Result result)
        {
            aspsEntities.Results.Attach(result);
            aspsEntities.Entry(result).State = EntityState.Deleted;
            return aspsEntities.SaveChanges() > 0;
        }

        public List<Result> ResultsList()
        {
            return aspsEntities.Results.ToList();
        }

        public bool ValidResult(string email, string course)
        {
            if (aspsEntities.Students.Find(email) != null && aspsEntities.Courses.Find(course) != null)
                return true;
            return false;
        }

        public Result FindResult(Result result)
        {
            if(aspsEntities.Results.Count(r => r.StudentEmail == result.StudentEmail && r.CourseID == result.CourseID) > 0)
            {
                return result;
            }
            return null;
        }
    }
}
