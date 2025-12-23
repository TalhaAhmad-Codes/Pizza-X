using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.PizzaDTOs;
using PizzaX.ApplicationCore.Interfaces.Repositories;
using PizzaX.ApplicationCore.Interfaces.Services;
using PizzaX.ApplicationCore.Mappers;

namespace PizzaX.Infrastructure.Services
{
    internal sealed class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public async Task<PagedResultDto<PizzaDto>> GetPizzasAsync(PizzaFilterDto filter)
        {
            var result = await _pizzaRepository.GetAsync(filter);

            return new PagedResultDto<PizzaDto>
            {
                Items = result.Items.Select(PizzaMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }
    }
}
