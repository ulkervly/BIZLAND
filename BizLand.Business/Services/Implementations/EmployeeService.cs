using BizLand.Business.Service.Interfaces;
using BizLand.Core.Repository.Interfaces;
using AutoMapper;
using BizLand.Business.HelperExt;
using Microsoft.AspNetCore.Hosting;
using BizLand.Business.DTOs.MemberDtos;
using BizLand.Core.Entities;

namespace BizLand.Business.Service.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _empRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHost;

        public EmployeeService(IEmployeeRepository empRepository,IMapper mapper,IWebHostEnvironment webHost)
        {
            _empRepository = empRepository;
            _mapper = mapper;
            _webHost = webHost;
        }
        public async Task Create(EmployeeCreateDto dto)
        {
            var newEmployee = new Employee();
            if (dto.FormFile != null)
            {

                if (dto.FormFile.ContentType != "image/png" && dto.FormFile.ContentType != "image/jpeg")
                {
                    throw new Exception();
                }
                if (dto.FormFile.Length > 1000000)
                {
                    throw new Exception();

                }
                newEmployee = _mapper.Map<Employee>(dto);
               /* newEmployee.ImageUrl =*/ /*Helper.SaveFile(_webHost.WebRootPath, "Uploads/Employees", dto.FormFile);*/
            }

            await _empRepository.CreateAsync(newEmployee);
            await _empRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var Employee = await _empRepository.GetByIdAsync(x => x.Id == id);
            if (Employee == null)
            {
                throw new Exception();
            }

            if (!string.IsNullOrEmpty(Employee.ImageUrl))
            {
                if (System.IO.File.Exists(Employee.ImageUrl))
                {
                    System.IO.File.Delete(Employee.ImageUrl);
                }
            }

            _empRepository.Delete(Employee);
            await _empRepository.CommitAsync();
        }

        public async Task<List<EmployeeGetDto>> GetAllAsync()
        {
            var Employees = await _empRepository.GetAllAsync();
            var mb = Employees.Select(x => new EmployeeGetDto()
            {
                
                MediaUrl = x.MediaUrl,
                FullName = x.FullName,
                ProfessionId = x.ProfessionId,
                IsDeleted = x.IsDeleted,
            }).ToList();
            return mb;
        }

        public async Task<EmployeeGetDto> GetByIdAsync(int id)
        {
            var Employee = await _empRepository.GetByIdAsync(x => x.Id == id);
            var mb = _mapper.Map<EmployeeGetDto>(Employee);
            return mb;
        }

        public async Task SoftDelete(int id)
        {
            var Employee = await _empRepository.GetByIdAsync(x => x.Id == id);
            if (Employee != null)
            {
                Employee.IsDeleted = !Employee.IsDeleted;
                await _empRepository.CommitAsync();
            }
        }

        public async Task Update(EmployeeUpdateDto dto)
        {
            var Employee = await _empRepository.GetByIdAsync(x => x.Id == dto.Id);
            if (Employee != null)
            {

                if (dto.FormFile.ContentType != "image/png" && dto.FormFile.ContentType != "image/jpeg")
                {
                    throw new Exception();
                }
                if (dto.FormFile.Length > 1000000)
                {
                    throw new Exception();

                }

                string deletePath = Path.Combine(_webHost.WebRootPath, "Uploads/Employees", Employee.ImageUrl);
                if (File.Exists(deletePath))
                {
                    File.Delete(deletePath);
                }

                Employee.ImageUrl = Helper.SaveFile(_webHost.WebRootPath, "Uploads/Employees", dto.FormFile);
            }

            Employee.FullName = dto.FullName;
            Employee.MediaUrl = dto.MediaUrl;
            Employee.ProfessionId = dto.ProfessionId;
            await _empRepository.CommitAsync();
        }
    }
}
