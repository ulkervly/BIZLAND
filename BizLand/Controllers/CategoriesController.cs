using BizLand.Business.DTOs.CategoryDtos;
using BizLand.Business.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BizLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(int), 201)]

        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(int), 201)]

        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(typeof(int), 404)]

        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            try
            {
                await _categoryService.Create(dto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(typeof(int), 404)]
        public async Task<IActionResult> Update( CategoryUpdateDto dto)
        {
            
            try
            {
                await _categoryService.Update(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(typeof(int), 204)]
        [ProducesResponseType(typeof(int), 404)]
        public async Task<IActionResult> SoftDelete(int id)
        {
            try
            {
                await _categoryService.SoftDelete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        [ProducesResponseType(typeof(int), 204)]
        [ProducesResponseType(typeof(int), 404)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
