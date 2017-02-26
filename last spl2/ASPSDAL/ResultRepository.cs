using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDAL
{
    public class ResultRepository
    {
        ASPSEntities db = null;

        public ResultRepository()
        {
            db = new ASPSEntities();
        }

        public bool AddResult(Result result)
        {
            db.Results.Add(result);
            return db.SaveChanges() > 0;
        }

        public bool EditResult(Result result)
        {
            db.Results.Attach(result);
            db.Entry(result).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool DeleteResult(Result result)
        {
            db.Results.Attach(result);
            db.Entry(result).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public List<Result> ResultsList()
        {
            return db.Results.ToList();
        }

        public Result GetResultById(long id)
        {
            return db.Results.FirstOrDefault(r => r.ResultID == id);
        }
    }
}
