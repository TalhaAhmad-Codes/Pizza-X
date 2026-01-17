using Microsoft.AspNetCore.Mvc;
using PizzaX.Application.DTOs.FriesDTOs;
using PizzaX.Application.DTOs.ProductDTOs.BaseProductUpdateDtos;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Domain.Common;

namespace PizzaX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class FriesController : ControllerBase
    {
        private readonly IFriesService service;

        public FriesController(IFriesService service)
            => this.service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] FriesFilterDto dto)
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
            var fries = await service.GetByIdAsync(id);
            return fries is null ? NotFound() : Ok(fries);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateFriesDto dto)
        {
            try
            {
                var fries = await service.CreateAsync(dto);
                return Ok(fries);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var result = await service.RemoveAsync(id);
            return result ? Ok("Fries has been removed successfully.") : NotFound();
        }

        [HttpPatch("update/image")]
        public async Task<IActionResult> UpdateImageAsync(ProductUpdateImageDto dto)
        {
            var result = await service.UpdateImageAsync(dto);
            return result ? Ok("Fries' image has been updated successfully.") : NotFound();
        }

        [HttpPatch("update/price")]
        public async Task<IActionResult> UpdatePriceAsync(ProductUpdatePriceDto dto)
        {
            try
            {
                var result = await service.UpdatePriceAsync(dto);
                return result ? Ok("Fries' price has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateQuantityAsync(ProductUpdateQuantityDto dto)
        {
            try
            {
                var result = await service.UpdateQuantityAsync(dto);
                return result ? Ok("Fries' quantity has been update successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateDescriptionAsync(ProductUpdateDescriptionDto dto)
        {
            try
            {
                var result = await service.UpdateDescriptionAsync(dto);
                return result ? Ok("Fries' description has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
