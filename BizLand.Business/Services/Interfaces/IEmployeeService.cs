using BizLand.Business.DTOs.MemberDtos;
using BizLand.Business.DTOs.ProfessionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task Create(EmployeeCreateDto dto);
        
        Task Delete(int id);
        Task SoftDelete(int id);
        Task Update(EmployeeUpdateDto dto);
        Task<EmployeeGetDto> GetByIdAsync(int id);
        Task<List<EmployeeGetDto>> GetAllAsync();
    }
}
