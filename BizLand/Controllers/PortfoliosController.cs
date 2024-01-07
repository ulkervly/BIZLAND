using BizLand.Business.DTOs.PortfolioDtos;
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
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var portfolios = await _portfolioService.GetAllAsync();
            return Ok(portfolios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var portfolio = await _portfolioService.GetByIdAsync(id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return Ok(portfolio);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(typeof(int), 404)]
        public async Task<IActionResult> Create([FromForm] PortfolioCreateDto dto)
        {
            try
            {
                await _portfolioService.Create(dto);
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
        public async Task<IActionResult> Update(int id, [FromForm] PortfolioUpdateDto dto)
        {
            dto.Id = id;
            try
            {
                await _portfolioService.Update(dto);
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
                await _portfolioService.SoftDelete(id);
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
                await _portfolioService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
