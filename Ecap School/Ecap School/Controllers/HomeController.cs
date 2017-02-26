using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Ecap_School.ActionResultAttributes;
using Ecap_School.Models;

namespace Ecap_School.Controllers
{
    [System.Web.Http.RoutePrefix("users")]
    public class HomeController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("all")]
        [ValidateModelStateFilter]
        public IHttpActionResult GetAll()
        {
            var users = new List<User>();
            users.Add(new User()
            {
                FirstName = "Mark",
                LastName = "Watney",
                UserName = "mwatney549"
            });

            users.Add(new Models.User()
            {
                FirstName = "Melissa",
                LastName = "Lewis",
                UserName = "cmdrlewis"
            });

            users.Add(new Models.User()
            {
                FirstName = "Rick",
                LastName = "Martinez",
                UserName = "mmartinez"
            });

            return Ok(users);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("add")]
        public IHttpActionResult Add(User user)
        {
            return Ok();
        }
    }
}
}
