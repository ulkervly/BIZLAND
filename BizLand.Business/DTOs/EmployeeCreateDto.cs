using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.MemberDtos
{
    public class EmployeeCreateDto
    {
        public string FullName { get; set; }
        public int ProfessionId { get; set; }
       
        public string MediaUrl { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
    }

    public class MemberCreateValidator : AbstractValidator<EmployeeCreateDto>
    {
        public MemberCreateValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(50);

            

            RuleFor(x => x.MediaUrl)
                .NotEmpty()
                .MaximumLength(50);

            
        }
    }

}
