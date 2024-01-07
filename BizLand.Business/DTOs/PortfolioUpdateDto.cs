using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.DTOs.PortfolioDtos
{
    public class PortfolioUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }

        [NotMapped]
        public IFormFile FormFile { get; set; }
    }
    public class PortfolioUpdateValidator : AbstractValidator<PortfolioUpdateDto>
    {
        public PortfolioUpdateValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(50);

        }
    }
}
