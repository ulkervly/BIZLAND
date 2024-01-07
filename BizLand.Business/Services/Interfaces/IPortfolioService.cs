using BizLand.Business.DTOs.CategoryDtos;
using BizLand.Business.DTOs.PortfolioDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Service.Interfaces
{
    public interface IPortfolioService
    {
        Task Create(PortfolioCreateDto dto);
        Task Update(PortfolioUpdateDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<PortfolioGetDto> GetByIdAsync(int id);
        Task<List<PortfolioGetDto>> GetAllAsync();
    }
}
