using Microsoft.AspNetCore.Mvc;
using PizzaX.Application.DTOs.DealDTOs;
using PizzaX.Application.DTOs.DealDTOs.DealUpdateDtos;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Domain.Common;

namespace PizzaX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class DealController : ControllerBase
    {
        private readonly IDealService service;

        public DealController(IDealService service)
            => this.service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] DealFilterDto filterDto)
        {
            try
            {
                var result = await service.GetAllAsync(filterDto);
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
            var deal = await service.GetByIdAsync(id);
            return deal is null ? NotFound() : Ok(deal);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateDealDto dto)
        {
            try
            {
                var deal = await service.CreateAsync(dto);
                return Ok(deal);
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
            return result ? Ok("Deal has been removed successfully.") : NotFound();
        }

        [HttpPatch("update/name")]
        public async Task<IActionResult> UpdateNameAsync(DealUpdateNameDto dto)
        {
            try
            {
                var result = await service.UpdateNameAsync(dto);
                return result ? Ok("Deal's name has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/description")]
        public async Task<IActionResult> UpdateDescripitonAsync(DealUpdateDescriptionDto dto)
        {
            try
            {
                var result = await service.UpdateDescriptionAsync(dto);
                return result ? Ok("Deal's description has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/price")]
        public async Task<IActionResult> UpdatePriceAsync(DealUpdatePriceDto dto)
        {
            try
            {
                var result = await service.UpdatePriceAsync(dto);
                return result ? Ok("Deal's price has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/add-items/products")]
        public async Task<IActionResult> AddDealProductItemsAsync(DealAddDealItemsDto dto)
        {
            try
            {
                var result = await service.AddDealProductItemAsync(dto);
                return result ? Ok("Deal items has been added successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/add-items/pizzas")]
        public async Task<IActionResult> AddDealPizzaItemsAsync(DealAddDealItemsDto dto)
        {
            try
            {
                var result = await service.AddDealPizzaItemAsync(dto);
                return result ? Ok("Deal items has been added successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/remove-items/product")]
        public async Task<IActionResult> RemoveDealProductItemsAsync(DealRemoveDealItemDto dto)
        {
            try
            {
                var result = await service.RemoveDealProductItemAsync(dto);
                return result ? Ok("Deal items has been removed successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/remove-items/pizza")]
        public async Task<IActionResult> RemoveDealPizzaItemsAsync(DealRemoveDealItemDto dto)
        {
            try
            {
                var result = await service.RemoveDealPizzaItemAsync(dto);
                return result ? Ok("Deal items has been removed successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
