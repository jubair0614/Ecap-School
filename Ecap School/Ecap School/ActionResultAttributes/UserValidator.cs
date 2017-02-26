using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ecap_School.Models;
using FluentValidation;

namespace Ecap_School.ActionResultAttributes
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("The First Name cannot be blank.")
                                    .Length(0, 100).WithMessage("The First Name cannot be more than 100 characters.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("The Last Name cannot be blank.");

            RuleFor(x => x.UserName).Length(8, 999).WithMessage("The user name must be at least 8 characters long.");
        }
    }
}