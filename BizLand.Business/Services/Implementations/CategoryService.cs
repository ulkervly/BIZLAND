using BizLand.Business.DTOs.CategoryDtos;
using BizLand.Business.DTOs.ProfessionDtos;
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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task Create(CategoryCreateDto dto)
        {
            if (dto != null)
            {
                var category = _mapper.Map<Category>(dto);
                await _categoryRepository.CreateAsync(category);
                await _categoryRepository.CommitAsync();
            }
        }

        public async Task Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(x => x.Id == id);
            if (category != null)
            {
                _categoryRepository.Delete(category);
                await _categoryRepository.CommitAsync();
            }
        }

        public async Task<List<CategoryGetDto>> GetAllAsync()
        {
            var category = await _categoryRepository.GetAllAsync();

            var pr = category.Select(x => new CategoryGetDto()
            {
                Id = x.Id,
                Name = x.Name,

            }).ToList();
            return pr;
        }

        public async Task<CategoryGetDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(x => x.Id == id);
            var srv = _mapper.Map<CategoryGetDto>(category);
            return srv;
        }

        public async Task SoftDelete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(x => x.Id == id);
            if (category != null)
            {
                category.IsDeleted = !category.IsDeleted;
                await _categoryRepository.CommitAsync();
            }
        }

        public async Task Update(CategoryUpdateDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(x => x.Id == dto.Id);
            if (category != null)
            {
                category = _mapper.Map(dto, category);
                await _categoryRepository.CommitAsync();
            }
        }
    }
}
