using Microsoft.AspNetCore.Mvc;
using PizzaX.Application.DTOs.ProductDTOs;
using PizzaX.Application.DTOs.ProductDTOs.ProductUpdateDtos;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Domain.Common;

namespace PizzaX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
            => this.service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] ProductFilterDto filterDto)
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
            var product = await service.GetByIdAsync(id);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateProductDto dto)
        {
            try
            {
                var product = await service.CreateAsync(dto);
                return Ok(product);
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
            return success ? Ok(success) : NotFound();
        }

        [HttpPatch("update/image")]
        public async Task<IActionResult> UpdateImageAsync(ProductUpdateImageDto dto)
        {
            var success = await service.UpdateImageAsync(dto);
            return success ? Ok("Product's image has been updated successfully.") : NotFound();
        }

        [HttpPatch("update/description")]
        public async Task<IActionResult> UpdateDescriptionAsync(ProductUpdateDescriptionDto dto)
        {
            try
            {
                var success = await service.UpdateDescriptionAsync(dto);
                return success ? Ok("Product's description has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/price")]
        public async Task<IActionResult> UpdatePriceAsync(ProductUpdatePriceDto dto)
        {
            try
            {
                var success = await service.UpdatePriceAsync(dto);
                return success ? Ok("Product's price has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/stock-status")]
        public async Task<IActionResult> UpdateStockStatusAsync(ProductUpdateStockStatusDto dto)
        {
            var success = await service.UpdateStockStatusAsync(dto);
            return success ? Ok("Product's stock status has been updated successfully.") : NotFound();
        }
    }
}
