using BizLand.Business.DTOs.RegisterDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.AccountDtos
{
    public class LoginDto
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UsernameOrEmail).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        }

    }
}
