using Microsoft.AspNetCore.Mvc;
using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Application.DTOs.ProductDTOs.BaseProductUpdateDtos;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Domain.Common;

namespace PizzaX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class PizzaController :  ControllerBase
    {
        private readonly IPizzaService service;

        public PizzaController(IPizzaService service)
            => this.service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PizzaFilterDto dto)
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
            var pizza = await service.GetByIdAsync(id);
            return pizza is null ? NotFound() : Ok(pizza);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreatePizzaDto dto)
        {
            try
            {
                var pizza = await service.CreateAsync(dto);
                return Ok(pizza);
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
            return result ? Ok("Pizza has been removed successfully.") : NotFound();
        }

        [HttpPatch("update/image")]
        public async Task<IActionResult> UpdateImageAsync(ProductUpdateImageDto dto)
        {
            var result = await service.UpdateImageAsync(dto);
            return result ? Ok("Image of the pizza has been updated successfully.") : NotFound();
        }

        [HttpPatch("update/price")]
        public async Task<IActionResult> UpdatePriceAsync(ProductUpdatePriceDto dto)
        {
            try
            {
                var result = await service.UpdatePriceAsync(dto);
                return result ? Ok("Price of the pizza has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/quantity")]
        public async Task<IActionResult> UpdateQuantityAsync(ProductUpdateQuantityDto dto)
        {
            try
            {
                var result = await service.UpdateQuantityAsync(dto);
                return result ? Ok("Quantity of the pizza has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/description")]
        public async Task<IActionResult> UpdateDescriptionAsync(ProductUpdateDescriptionDto dto)
        {
            try
            {
                var result = await service.UpdateDescriptionAsync(dto);
                return result ? Ok("Description of the pizza has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
