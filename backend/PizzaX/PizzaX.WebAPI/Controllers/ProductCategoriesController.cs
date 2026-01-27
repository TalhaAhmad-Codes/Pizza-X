using Microsoft.AspNetCore.Mvc;
using PizzaX.Application.DTOs.BaseCategoryDTOs;
using PizzaX.Application.DTOs.BaseCategoryDTOs.BaseCategoryUpdateDtos;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Domain.Common;

namespace PizzaX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryService service;

        public ProductCategoriesController(IProductCategoryService service)
            => this.service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] BaseCategoryFilterDto dto)
        {
            var result = await service.GetAllAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var category = await service.GetByIdAsync(id);
            return category is null ? NotFound() : Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateBaseCategoryDto dto)
        {
            try
            {
                var category = await service.CreateAsync(dto);
                return category is null ? NotFound() : Ok(category);
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
            return result ? Ok("Product category has been removed successfully.") : NotFound();
        }

        [HttpPatch("update/name")]
        public async Task<IActionResult> UpdateNameAsync(BaseCategoryUpdateNameDto dto)
        {
            try
            {
                var result = await service.UpdateNameAsync(dto);
                return result ? Ok("Product category's name has been updated successfully.") : NotFound();
            }
            catch (DomainException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
