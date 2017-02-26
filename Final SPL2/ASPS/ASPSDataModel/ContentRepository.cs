using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDataModel
{
    public class ContentRepository
    {
        ASPSEntities aspsEntities = null;

        public ContentRepository()
        {
            aspsEntities = new ASPSEntities();
        }

        public bool AddContent(Content content)
        {
            aspsEntities.Contents.Add(content);
            return aspsEntities.SaveChanges() > 0;
        }

        public bool EditContent(Content content)
        {
            aspsEntities.Contents.Attach(content);
            aspsEntities.Entry(content).State = EntityState.Modified;
            return aspsEntities.SaveChanges() > 0;
        }

        public bool DeleteContent(Content content)
        {
            aspsEntities.Contents.Attach(content);
            aspsEntities.Entry(content).State = EntityState.Deleted;
            return aspsEntities.SaveChanges() > 0;
        }

        public List<Content> ContentsList()
        {
            return aspsEntities.Contents.ToList();
        } 
    }
}
