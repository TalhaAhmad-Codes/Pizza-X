using Microsoft.AspNetCore.Mvc;
using PizzaX.Application.DTOs.BaseProductDTOs.BaseProductUpdateDtos;
using PizzaX.Application.DTOs.ProductDTOs;
using PizzaX.Application.DTOs.ProductDTOs.ProductUpdateDtos;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Domain.Common;

namespace PizzaX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ProductsController : ControllerBase
    {
        private readonly IProductService service;

        public ProductsController(IProductService service)
            => this.service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(ProductFilterDto dto)
        {
            var result = await service.GetAllAsync(dto);
            return Ok(result);
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
            var result = await service.RemoveAsync(id);
            return result ? Ok("Product has been removed successfully.") : NotFound();
        }

        [HttpPatch("update/name")]
        public async Task<IActionResult> UpdateNameAsync(ProductUpdateNameDto dto)
        {
            try
            {
                var result = await service.UpdateNameAsync(dto);
                return result ? Ok("Product's name has been update successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("update/image")]
        public async Task<IActionResult> UpdateImageAsync(ProductUpdateImageDto dto)
        {
            try
            {
                var result = await service.UpdateImageAsync(dto);
                return result ? Ok("Product's image has been update successfully.") : NotFound();
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
                var result = await service.UpdatePriceAsync(dto);
                return result ? Ok("Product's price has been update successfully.") : NotFound();
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
                return result ? Ok("Product's quantity has been update successfully.") : NotFound();
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
                return result ? Ok("Product's description has been update successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
