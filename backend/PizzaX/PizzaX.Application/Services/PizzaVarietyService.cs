using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaVarietyDTOs;
using PizzaX.Application.DTOs.PizzaVarietyDTOs.PizzaVarietyUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;

namespace PizzaX.Application.Services
{
    public sealed class PizzaVarietyService : IPizzaVarietyService
    {
        private readonly IPizzaVarietyRepository repository;

        public PizzaVarietyService(IPizzaVarietyRepository repository)
            => this.repository = repository;

        public async Task<PagedResultDto<PizzaVarietyDto>> GetAllAsync(PizzaVarietyFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<PizzaVarietyDto>
            {
                Items = result.Items.Select(PizzaVarietyMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<bool> UpdateNameAsync(PizzaVarietyNameUpdateDto dto)
        {
            var variety = await repository.GetByIdAsync(dto.Id);

            if (variety is null) return false;

            variety.UpdateName(dto.Name);
            await repository.UpdateAsync(variety);
            return true;
        }
    }
}
