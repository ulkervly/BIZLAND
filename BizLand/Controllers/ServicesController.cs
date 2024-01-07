using BizLand.Business.DTOs.ServiceDtos;
using BizLand.Business.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _servicesService;

        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(int), 201)]

        public async Task<IActionResult> GetAll()
        {
            var services = await _servicesService.GetAllAsync();
            return Ok(services);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(int), 201)]
        public async Task<IActionResult> Get(int id)
        {
            var service = await _servicesService.GetByIdAsync(id);
            return Ok(service);
        }
        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]

        [ProducesResponseType(typeof(int), 201)]
        public async Task<IActionResult> Create(ServiceCreateDto dto)
        {
            await _servicesService.Create(dto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]

        [ProducesResponseType(typeof(int), 201)]
        public async Task<IActionResult> Update(ServiceUpdateDto dto)
        {
            await _servicesService.Update(dto);
            return Ok();
        }


        [HttpPatch("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]

        [ProducesResponseType(typeof(int), 204)]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await _servicesService.SoftDelete(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        [ProducesResponseType(typeof(int), 204)]
        public async Task<IActionResult> Delete(int id)
        {
            await _servicesService.Delete(id);
            return NoContent();
        }
    }
}
