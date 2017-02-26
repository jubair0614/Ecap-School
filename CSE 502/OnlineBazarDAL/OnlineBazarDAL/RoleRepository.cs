using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBazarDAL
{
    public class RoleRepository
    {
        OnlineBazarEntities onlineBazarEntites = null;

        public RoleRepository()
        {
            onlineBazarEntites = new OnlineBazarEntities();
        }

        public bool AddRole(Role role)
        {
            onlineBazarEntites.Roles.Add(role);
            return onlineBazarEntites.SaveChanges() > 0;
        }

        public bool EditRole(Role role)
        {
            onlineBazarEntites.Roles.Attach(role);
            onlineBazarEntites.Entry(role).State = System.Data.Entity.EntityState.Modified;
            return onlineBazarEntites.SaveChanges() > 0;
        }

        public bool DeleteRole(Role role)
        {
            onlineBazarEntites.Roles.Attach(role);
            onlineBazarEntites.Entry(role).State = System.Data.Entity.EntityState.Deleted;
            return onlineBazarEntites.SaveChanges() > 0;
        }

        public List<Role> GetRoleList()
        {
            return onlineBazarEntites.Roles.ToList();
        }

        public Role GetRoleById(int roleId)
        {
            return onlineBazarEntites.Roles.FirstOrDefault(r => r.Id == roleId);
        }
    }
}
