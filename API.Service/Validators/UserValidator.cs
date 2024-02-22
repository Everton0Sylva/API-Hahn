using API.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.FullName)
                .NotEmpty().WithMessage("Please enter the full name.")
                .NotNull().WithMessage("Please enter the  full name.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Please enter the email.")
                .NotNull().WithMessage("Please enter the email.");

            RuleFor(c => c.Company)
                .NotEmpty().WithMessage("Please enter the clientid.")
                .NotNull().WithMessage("Please enter the clientid.");
        }
    }
}
