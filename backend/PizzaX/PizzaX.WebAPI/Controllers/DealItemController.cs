using Microsoft.AspNetCore.Mvc;
using PizzaX.Application.DTOs.DealItemDTOs;
using PizzaX.Application.DTOs.DealItemDTOs.DealItemUpdateDtos;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Domain.Common;

namespace PizzaX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealItemController : ControllerBase
    {
        private readonly IDealItemService service;

        public DealItemController(IDealItemService service)
            => this.service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] DealItemFilterDto dto)
        {
            try
            {
                var result = await service.GetDealItemAsync(dto);
                return Ok(result);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:uuid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var dealItem = await service.GetByIdAsync(id);
            return dealItem is null ? NotFound() : Ok(dealItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateDealItemDto dto)
        {
            try
            {
                var dealItem = await service.CreateAsync(dto);
                return Ok(dealItem);
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var success = await service.RemoveAsync(id);
            return success ? Ok("Deal item has been removed successfully.") : NotFound();
        }

        [HttpPatch("update/quantity")]
        public async Task<IActionResult> UpdateQuantityAsync(DealItemUpdateQuantityDto dto)
        {
            try
            {
                var success = await service.UpdateQuantityAsync(dto);
                return success ? Ok("Deal item's quantity has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/product")]
        public async Task<IActionResult> ChangeProductAsync(DealItemChangeProductDto dto)
        {
            try
            {
                var success = await service.ChangeProductAsync(dto);
                return success ? Ok("Deal item's product has been changes successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
