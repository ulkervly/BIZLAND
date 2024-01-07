using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.ProfessionDtos
{
    public class ProfessionCreateDto
    {
        public string Name { get; set; }
    }

    public class ProfessionCreateDtoValidator : AbstractValidator<ProfessionCreateDto>
    {
        public ProfessionCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}
