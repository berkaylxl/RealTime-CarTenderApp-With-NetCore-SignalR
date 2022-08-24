using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Entities;

namespace TenderApp.Business.Validation
{
    public class CorporateCustomerRegisterValidator:AbstractValidator<CorporateCustomer>
    {
        public CorporateCustomerRegisterValidator()
        {
            RuleFor(x => x.CompanyTitle).NotEmpty().MaximumLength(50);

            RuleFor(x => x.CompanyType).NotEmpty().MaximumLength(50);

            RuleFor(x => x.TaxNo).NotEmpty().Length(10);
            RuleFor(x => x.TaxOffice).NotEmpty().MaximumLength(50);

            RuleFor(x => x.Email).EmailAddress().NotEmpty();

            RuleFor(x => x.Password).NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                    .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");

            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();

        }
    }
}
