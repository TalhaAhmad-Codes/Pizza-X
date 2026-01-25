using Microsoft.AspNetCore.Mvc;
using PizzaX.Application.DTOs.DrinkDTOs;
using PizzaX.Application.DTOs.DrinkDTOs.DrinkUpdateDtos;
using PizzaX.Application.DTOs.ProductDTOs.BaseProductUpdateDtos;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Domain.Common;

namespace PizzaX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class DrinkController : ControllerBase
    {
        private readonly IDrinkService service;

        public DrinkController(IDrinkService service)
            => this.service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] DrinkFilterDto dto)
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
            var drink = await service.GetByIdAsync(id);
            return drink is null ? NotFound() : Ok(drink);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateDrinkDto dto)
        {
            try
            {
                var drink = await service.CreateAsync(dto);
                return Ok(drink);
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
            return result ? Ok("Drink has been removed successfully.") : NotFound();
        }

        [HttpPatch("update/image")]
        public async Task<IActionResult> UpdateImageAsync(ProductUpdateImageDto dto)
        {
            var result = await service.UpdateImageAsync(dto);
            return result ? Ok("Drink's image has been updated successfully.") : NotFound();
        }

        [HttpPatch("update/price")]
        public async Task<IActionResult> UpdatePriceAsync(ProductUpdatePriceDto dto)
        {
            try
            {
                var result = await service.UpdatePriceAsync(dto);
                return result ? Ok("Drink's price has been updated successfully.") : NotFound();
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
                return result ? Ok("Drink's quantity has been updated successfully.") : NotFound();
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
                return result ? Ok("Drink's description has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/company")]
        public async Task<IActionResult> UpdateCompanyAsync(DrinkUpdateDetailsCompanyNameDto dto)
        {
            try
            {
                var result = await service.UpdateCompanyDetailsAsync(dto);
                return result ? Ok("The company name for drink details has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/retailer")]
        public async Task<IActionResult> UpdateRetailerAsync(DrinkUpdateDetailsRetailerContactNumber dto)
        {
            try
            {
                var result = await service.UpdateRetailerNumberAsync(dto);
                return result ? Ok("The retailer number for drink details has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
