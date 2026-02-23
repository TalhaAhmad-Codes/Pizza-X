using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.PizzaVarietyDTOs;
using PizzaX.Application.DTOs.PizzaVarietyDTOs.PizzaVarietyUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Services
{
    public sealed class PizzaVarietyService : IPizzaVarietyService
    {
        private readonly IPizzaVarietyRepository repository;

        public PizzaVarietyService(IPizzaVarietyRepository repository)
            => this.repository = repository;

        public async Task<PizzaVarietyDto> CreateAsync(CreatePizzaVarietyDto dto)
        {
            var variety = PizzaVariety.Create(
                name: dto.Name
            );

            await repository.AddAsync(variety);
            return PizzaVarietyMapper.ToDto(variety);
        }

        public async Task<PagedResultDto<PizzaVarietyDto>> GetAllAsync(PizzaVarietyFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<PizzaVarietyDto>
            {
                Items = result.Items.Select(PizzaVarietyMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<PizzaVarietyDto?> GetByIdAsync(Guid id)
        {
            var variety = await repository.GetByIdAsync(id);

            return variety is null ? null : PizzaVarietyMapper.ToDto(variety);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var variety = await repository.GetByIdAsync(id);

            if (variety is null) return false;

            await repository.RemoveAsync(variety);
            return true;
        }

        public async Task<bool> UpdateNameAsync(PizzaVarietyUpdateNameDto dto)
        {
            var variety = await repository.GetByIdAsync(dto.Id);

            if (variety is null) return false;

            variety.UpdateName(dto.Name);
            await repository.UpdateAsync(variety);
            return true;
        }
    }
}
