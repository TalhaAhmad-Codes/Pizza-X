using PizzaX.ApplicationCore.DTOs.Common;
using PizzaX.ApplicationCore.DTOs.PizzaVarietyDTOs;
using PizzaX.ApplicationCore.Interfaces.Repositories;
using PizzaX.ApplicationCore.Interfaces.Services;
using PizzaX.ApplicationCore.Mappers;

namespace PizzaX.ApplicationCore.Services
{
    internal sealed class PizzaVarietyService : IPizzaVarietyService
    {
        private readonly IPizzaVarietyRepository _pizzaVarietyRepository;

        public PizzaVarietyService(IPizzaVarietyRepository pizzaVarietyRepository)
            => _pizzaVarietyRepository = pizzaVarietyRepository;

        public async Task<PagedResultDto<PizzaVarietyDto>> GetPizzaVarietiesAsync(PizzaVarietyFilterDto filter)
        {
            var result = await _pizzaVarietyRepository.GetAsync(filter);

            return new PagedResultDto<PizzaVarietyDto>
            {
                Items = result.Items.Select(PizzaVarietyMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }
    }
}
