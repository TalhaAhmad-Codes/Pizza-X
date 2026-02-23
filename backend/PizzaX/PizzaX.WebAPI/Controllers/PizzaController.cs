using Microsoft.AspNetCore.Mvc;
using PizzaX.Application.DTOs.PizzaDTOs;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Domain.Common;

namespace PizzaX.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class PizzaController : ControllerBase
    {
        private readonly IPizzaService service;

        public PizzaController(IPizzaService service)
            => this.service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PizzaFilterDto filterDto)
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
            var success = await service.RemoveAsync(id);
            return success ? Ok("Pizza has been removed successfully.") : NotFound();
        }
    }
}
