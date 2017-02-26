using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecap_School.ActionResultAttributes;
using FluentValidation.Attributes;
using Microsoft.AspNet.Identity;

namespace Ecap_School.Models
{
    [Validator(typeof(UserValidator))]
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}