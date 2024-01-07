using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.CategoryDtos
{

        public class CategoryUpdateDto
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        public class CategoryUpdateDtoDtoValidator : AbstractValidator<CategoryUpdateDto>
        {
            public CategoryUpdateDtoDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            }
        }
    
}
