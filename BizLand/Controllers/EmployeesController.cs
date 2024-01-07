using BizLand.Business.DTOs;
using BizLand.Business.Service.Interfaces;
using BizLand.Business.DTOs.MemberDtos;
using BizLand.Business.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BizLand.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _EmployeeService;

        public EmployeeController(IEmployeeService EmployeeService)
        {
            _EmployeeService = EmployeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Employees = await _EmployeeService.GetAllAsync();
            return Ok(Employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Employee = await _EmployeeService.GetByIdAsync(id);
            if (Employee == null)
            {
                return NotFound();
            }
            return Ok(Employee);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(typeof(int), 201)]
        public async Task<IActionResult> Create([FromForm] EmployeeCreateDto dto)
        {
           
                await _EmployeeService.Create(dto);
                return Ok("Employee created successfully");
            
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(typeof(int), 404)]
        public async Task<IActionResult> Update( [FromForm] EmployeeUpdateDto dto)
        {
           
            try
            {
                await _EmployeeService.Update(dto);
                return Ok("Employee updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(typeof(int), 404)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _EmployeeService.Delete(id);
                return Ok("Employee deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        [Authorize(Roles ="SuperAdmin,Admin")]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(typeof(int), 404)]
        public async Task<ActionResult> SoftDelete(int id)
        {
            try
            {
                await _EmployeeService.SoftDelete(id);
                return Ok("Employee soft deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
