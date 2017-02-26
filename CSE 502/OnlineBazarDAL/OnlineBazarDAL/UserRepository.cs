using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBazarDAL
{
    public class UserRepository
    {
        OnlineBazarEntities onlineBazarEntites = null;

        public UserRepository()
        {
            onlineBazarEntites = new OnlineBazarEntities();
        }

        public bool AddUser(User user)
        {
            onlineBazarEntites.Users.Add(user);
            return onlineBazarEntites.SaveChanges() > 0;
        }

        public bool EditUser(User user)
        {
            onlineBazarEntites.Users.Attach(user);
            onlineBazarEntites.Entry(user).State = System.Data.Entity.EntityState.Modified;
            return onlineBazarEntites.SaveChanges() > 0;
        }

        public bool DeleteUser(User user)
        {
            onlineBazarEntites.Users.Attach(user);
            onlineBazarEntites.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            return onlineBazarEntites.SaveChanges() > 0;
        }

        public List<User> UserList()
        {
            return onlineBazarEntites.Users.ToList();
        }
        

        public User getUserById(int UserId)
        {
            return onlineBazarEntites.Users.FirstOrDefault(u => u.Id == UserId);
        }
    }
}
