using BizLand.Core.Entities;
using AutoMapper;
using BizLand.Business.DTOs.CategoryDtos;
using BizLand.Business.DTOs.MemberDtos;
using BizLand.Business.DTOs.ProfessionDtos;
using BizLand.Business.DTOs.PortfolioDtos;
using BizLand.Business.DTOs.AccountDtos;
using BizLand.Business.DTOs.RegisterDtos;
using BizLand.Business.DTOs.ServiceDtos;

namespace BizLand.Business.MappingProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
           
            CreateMap<Services, ServiceGetDto>().ReverseMap();
            CreateMap<Services, ServiceCreateDto>().ReverseMap();
            CreateMap<Services, ServiceUpdateDto>().ReverseMap();
            CreateMap<EmployeeCreateDto, Employee>().ReverseMap();
            CreateMap<EmployeeUpdateDto, Employee>().ReverseMap();
            CreateMap<EmployeeGetDto, Employee>().ReverseMap();
            CreateMap<ProfessionCreateDto, Profession>().ReverseMap();
            CreateMap<ProfessionGetDto, Profession>().ReverseMap();
            CreateMap<ProfessionUpdateDto, Profession>().ReverseMap();
            CreateMap<CategoryCreateDto, Category>().ReverseMap();
            CreateMap<CategoryGetDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
            CreateMap<PortfolioCreateDto, Portfolio>().ReverseMap();
            CreateMap<PortfolioGetDto, Portfolio>().ReverseMap();
            CreateMap<PortfolioUpdateDto, Portfolio>().ReverseMap();

            CreateMap<RegisterDto, AppUser>().ReverseMap();
            CreateMap<LoginDto, AppUser>().ReverseMap();

        }
    }
}
