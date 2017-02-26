using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public String Index()
        {
            return "This is my <b>default</b> action..........";
        }

        // GET: HelloWorld/Welcome/
        public String Welcome(String name, int numTimes = 1)
        {
            return HttpUtility.HtmlEncode("Name " + name + " numTimes " + numTimes);
        }
    }
}