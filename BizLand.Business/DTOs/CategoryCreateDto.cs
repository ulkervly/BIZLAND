using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.CategoryDtos
{
   
        public class CategoryCreateDto
        {
            public string Name { get; set; }
        }

        public class CategoryCreateDtoDtoValidator : AbstractValidator<CategoryCreateDto>
        {
            public CategoryCreateDtoDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            }
        }
    
}
