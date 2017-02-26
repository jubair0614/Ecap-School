using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ecap_School.Controllers
{

    [RoutePrefix("jubair")]
    public class CustomController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "I love Selise!!!!! <3 <3 :D :D";
        }

        [HttpPost]
        public string Index(string id)
        {
            return $"I love Selise!!!!! <3 <3 :D :D {id}";
        }

        [Route("{id:int}")]
        [HttpGet]
        public string AttributeRoute()
        {
            return "This is attribute route";
        }

    }
}
