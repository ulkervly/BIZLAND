using BizLand.Business.DTOs.ServiceDtos;

namespace BizLand.Business.Service.Interfaces
{
    public interface IServicesService
    {
        Task Create(ServiceCreateDto dto);
        Task Update(ServiceUpdateDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<ServiceGetDto> GetByIdAsync(int id);
        Task<List<ServiceGetDto>> GetAllAsync();
    }
}
