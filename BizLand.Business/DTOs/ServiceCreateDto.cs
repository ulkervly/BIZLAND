using FluentValidation;

namespace BizLand.Business.DTOs.ServiceDtos
{
    public class ServiceCreateDto
    {
        public string IconUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class ServiceCreateDtoValidator : AbstractValidator<ServiceCreateDto>
    {
        public ServiceCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.IconUrl)
                .NotEmpty().NotNull().MaximumLength(100);
            RuleFor(x => x.Description)
                .NotEmpty().NotNull().MaximumLength(50);

            
        }
    }
}
