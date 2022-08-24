
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Entities;
using TenderApp.Entities.DTOs;

namespace TenderApp.Business.Validation
{
    public class LoginValidator : AbstractValidator<User>
    {
        public LoginValidator()
        {
            
            RuleFor(x => x.Email).EmailAddress().NotEmpty();

            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty");
        }
    }
}
