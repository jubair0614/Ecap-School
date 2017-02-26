using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPSWebApp.BusinessCode
{
    public class Password
    {
        public bool ComparePassword(string password, string confirmPassword)
        {
            if (password == confirmPassword) return true;
            return false;
        }
    }
}