using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDAL
{
    public class ContentRepository
    {
        ASPSEntities db = null;

        public ContentRepository()
        {
            db = new ASPSEntities();
        }

        public bool AddContent(Content content)
        {
            db.Contents.Add(content);
            return db.SaveChanges() > 0;
        }

        public bool EditContent(Content content)
        {
            db.Contents.Attach(content);
            db.Entry(content).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool DeleteContent(Content content)
        {
            db.Contents.Attach(content);
            db.Entry(content).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public Content GetContentById(long id)
        {
            return db.Contents.FirstOrDefault(c => c.ContentID == id);
        }

        public List<Content> GetContentsByStudentId(long id)
        {
            return db.Contents.Where(c => c.StudentID == id).ToList();
        } 

        public List<Content> GetContentsList()
        {
            return db.Contents.ToList();
        } 
    }
}
