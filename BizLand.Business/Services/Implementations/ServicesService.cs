using BizLand.Business.DTOs.ServiceDtos;
using BizLand.Business.Service.Interfaces;
using BizLand.Core.Entities;
using BizLand.Core.Repository.Interfaces;
using BizLand.Data.Repository.Implementations;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Service.Implementations
{
    public class ServicesService : IServicesService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;

        public ServicesService(IServiceRepository serviceRepository,IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }


        public async Task Create(ServiceCreateDto dto)
        {
            if ( dto != null ) 
            {
                var service = _mapper.Map<Services>( dto );
                await _serviceRepository.CreateAsync( service );  
                await _serviceRepository.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(x=>x.Id == id);
            if ( service != null )
            {
                _serviceRepository.Delete(service);
                await _serviceRepository.CommitAsync();
            }
        }

        public async Task SoftDelete(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(x => x.Id == id);
            if (service != null)
            {
                service.IsDeleted = !service.IsDeleted;
                await _serviceRepository.CommitAsync();
            }
        }

        public async Task<List<ServiceGetDto>> GetAllAsync()
        {
            var service = await _serviceRepository.GetAllAsync();

            var srv = service.Select(x => new ServiceGetDto()
            {
                Id = x.Id,
                IconUrl = x.İconUrl,
                Title = x.Title,
                Description = x.Description,

            }).ToList();

            return srv;
        }

        public async Task<ServiceGetDto> GetByIdAsync(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(x => x.Id == id);
            var srv = _mapper.Map<ServiceGetDto>( service );
            return srv;
        }

        public async Task Update(ServiceUpdateDto dto)
        {
            var service = await _serviceRepository.GetByIdAsync(x=>x.Id == dto.Id);
            if (service != null)
            {
               service = _mapper.Map(dto, service);
               await _serviceRepository.CommitAsync();
            }
        }
    }
}
