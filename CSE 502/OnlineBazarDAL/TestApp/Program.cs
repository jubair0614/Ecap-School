using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OnlineBazarDAL.RoleRepository roleRepository = new OnlineBazarDAL.RoleRepository();
            OnlineBazarDAL.Role role = new OnlineBazarDAL.Role();

            role.RoleName = "Admin";
            role.RoleDescription = "Super Admin";
            if (roleRepository.AddRole(role))
            {
                Console.WriteLine("Role added successful");
            }
            else
            {
                Console.WriteLine("Role added failed");
            }

            OnlineBazarDAL.UserRepository userRepository = new OnlineBazarDAL.UserRepository();
            OnlineBazarDAL.User user = new OnlineBazarDAL.User();
            user.UserName = "jubair";
            user.Email = "jubair@gmail.com";
            user.Password = "123";
            user.RoleId = 1;
            if (userRepository.AddUser(user))
            {
                Console.WriteLine("User " + user.UserName + " password " + user.Password + " email " + " role_Id: " + user.RoleId );
            }
            else
            {
                Console.WriteLine("User added failed");
            }
        }
    }
}
