using BizLand.Business.DTOs.ProfessionDtos;
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
    public class ProfessionService : IProfessionService
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly IMapper _mapper;

        public ProfessionService(IProfessionRepository professionRepository,IMapper mapper)
        {
            _professionRepository = professionRepository;
            _mapper = mapper;
        }
        public async Task Create(ProfessionCreateDto dto)
        {
            if (dto != null)
            {
                var prof = _mapper.Map<Profession>(dto);
                await _professionRepository.CreateAsync(prof);
                await _professionRepository.CommitAsync();
            }
            
        }

        public async Task Delete(int id)
        {
            var prof = await _professionRepository.GetByIdAsync(x => x.Id == id);
            if (prof != null)
            {
                _professionRepository.Delete(prof);
                await _professionRepository.CommitAsync();
            }
        }

        public async Task<List<ProfessionGetDto>> GetAllAsync()
        {
            var prof = await _professionRepository.GetAllAsync();

            var pr = prof.Select(x => new ProfessionGetDto()
            {
                Id = x.Id,
                Name = x.Name,

            }).ToList();

            return pr;
        }

        public async Task<ProfessionGetDto> GetByIdAsync(int id)
        {
            var prof = await _professionRepository.GetByIdAsync(x => x.Id == id);
            var srv = _mapper.Map<ProfessionGetDto>(prof);
            return srv;
        }

        public async Task SoftDelete(int id)
        {
            var prof = await _professionRepository.GetByIdAsync(x => x.Id == id);
            if (prof != null)
            {
                prof.IsDeleted = !prof.IsDeleted;
                await _professionRepository.CommitAsync();
            }
        }

        public async Task Update(ProfessionUpdateDto dto)
        {
            var prof = await _professionRepository.GetByIdAsync(x => x.Id == dto.Id);
            if (prof != null)
            {
                prof = _mapper.Map(dto, prof);
                await _professionRepository.CommitAsync();
            }
        }
    }
}
