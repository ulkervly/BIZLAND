using BizLand.Business.DTOs.ProfessionDtos;
using BizLand.Business.DTOs.ServiceDtos;
using BizLand.Business.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionsController : ControllerBase
    {
        private readonly IProfessionService _professionService;

        public ProfessionsController(IProfessionService professionService)
        {
            _professionService = professionService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(int), 201)]

        public async Task<IActionResult> GetAll()
        {
            var profs = await _professionService.GetAllAsync();
            return Ok(profs);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(int), 201)]
        public async Task<IActionResult> Get(int id)
        {
            var prof = await _professionService.GetByIdAsync(id);
            return Ok(prof);
        }
        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]

        [ProducesResponseType(typeof(int), 201)]
        public async Task<IActionResult> Create(ProfessionCreateDto dto)
        {
            await _professionService.Create(dto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]

        [ProducesResponseType(typeof(int), 201)]
        public async Task<IActionResult> Update(ProfessionUpdateDto dto)
        {
            await _professionService.Update(dto);
            return Ok();
        }


        [HttpPatch("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]

        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _professionService.SoftDelete(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        [ProducesResponseType(typeof(int), 204)]
        public async Task<IActionResult> Delete(int id)
        {
            await _professionService.Delete(id);
            return NoContent();
        }
    }
}
