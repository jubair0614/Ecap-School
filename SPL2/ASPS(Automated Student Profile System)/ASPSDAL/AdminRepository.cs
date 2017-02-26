using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPSDAL
{
    public class AdminRepository
    {
        ASPSEntities db = null;

        public AdminRepository()
        {
            db = new ASPSEntities();
        }

        public bool AddAdmin(Admin admin)
        {
            db.Admins.Add(admin);
            return db.SaveChanges() > 0;
        }

        public bool EditAdmin(Admin admin)
        {
            db.Admins.Attach(admin);
            db.Entry(admin).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool DeleteAdmin(Admin admin)
        {
            db.Admins.Attach(admin);
            db.Entry(admin).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        public List<Admin> AdminsList()
        {
            return db.Admins.ToList();
        }

        public Admin GetAdminByEmail(string email)
        {
            return db.Admins.FirstOrDefault(a => a.AdminEmail == email);
        }

        public Admin GetAdminById(long id)
        {
            return db.Admins.FirstOrDefault(a => a.AdminID == id);
        }

        public bool ValidateAdmin(string email, string password)
        {
            return db.Admins.Count(a =>a.AdminEmail == email && a.Password == password) > 0;
        }
    }
}
