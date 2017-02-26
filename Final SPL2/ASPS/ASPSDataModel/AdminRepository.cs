using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDataModel
{
    public class AdminRepository
    {
        ASPSEntities aspsEntities = null;

        public AdminRepository()
        {
            aspsEntities = new ASPSEntities();
        }

        public bool AddAdmin(Admin admin)
        {
            aspsEntities.Admins.Add(admin);
            return aspsEntities.SaveChanges() > 0;
        }

        public bool EditAdmin(Admin admin)
        {
            aspsEntities.Admins.Attach(admin);
            aspsEntities.Entry(admin).State = EntityState.Modified;
            return aspsEntities.SaveChanges() > 0;
        }

        public bool DeleteAdmin(Admin admin)
        {
            aspsEntities.Admins.Attach(admin);
            aspsEntities.Entry(admin).State = EntityState.Deleted;
            return aspsEntities.SaveChanges() > 0;
        }

        public List<Admin> AdminsList()
        {
            return aspsEntities.Admins.ToList();
        }

        public Admin FindSystemAdmin(Admin admin)
        {
            return aspsEntities.Admins.Find(admin.AdminID);
        }

        public Admin FindSystemAdmin(int adminID)
        {
            return aspsEntities.Admins.Find(adminID);
        }

        public bool ValidSystemAdmin(string email, string password)
        {
            return
                aspsEntities.Admins.Count(
                    s => s.AdminEmail == email && s.Password == password) > 0;
        }
    }
}
