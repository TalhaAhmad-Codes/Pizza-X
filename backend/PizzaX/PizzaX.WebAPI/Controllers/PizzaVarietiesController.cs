using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaX.Application.DTOs.BaseCategoryDTOs;
using PizzaX.Application.DTOs.BaseCategoryDTOs.BaseCategoryUpdateDtos;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Domain.Common;

namespace PizzaX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class PizzaVarietiesController : ControllerBase
    {
        private readonly IPizzaVarietyService service;

        public PizzaVarietiesController(IPizzaVarietyService service)
            => this.service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] BaseCategoryFilterDto dto)
        {
            try
            {
                var result = await service.GetAllAsync(dto);
                return Ok(result);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var variety = await service.GetByIdAsync(id);
            return variety is null ? NotFound() : Ok(variety);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBaseCategoryDto dto)
        {
            try
            {
                var variety = await service.CreateAsync(dto);
                return Ok(variety);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
            catch (DbUpdateException e)
            {
                return BadRequest($"This pizza variety already exists. Details:\n{e.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var result = await service.RemoveAsync(id);
            return result ? Ok("Pizza variety and all related pizza entities has been removed successfully.") : NotFound();
        }

        [HttpPatch("update/name")]
        public async Task<IActionResult> UpdatePizzaVarietyNameAsync(BaseCategoryUpdateNameDto dto)
        {
            try
            {
                var result = await service.UpdateNameAsync(dto);
                return result ? Ok($"Pizza variety's name has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
