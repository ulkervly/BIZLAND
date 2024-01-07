using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.ProfessionDtos
{
    public class ProfessionUpdateDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ProfessionUpdateDtoValidator : AbstractValidator<ProfessionUpdateDto>
    {
        public ProfessionUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}
