using PizzaX.Application.DTOs.Common;
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

        //public async Task<BaseCategoryDto> CreateAsync(CreateBaseCategoryDto dto)
        //{
        //    var variety = PizzaVariety.Create(
        //        name: dto.Name
        //    );

        //    await repository.AddAsync(variety);
        //    return CategoryMapper.PizzaVarietyToDto(variety);
        //}

        //public async Task<PagedResultDto<BaseCategoryDto>> GetAllAsync(BaseCategoryFilterDto filterDto)
        //{
        //    var result = await repository.GetAllAsync(filterDto);

        //    return new PagedResultDto<BaseCategoryDto>
        //    {
        //        Items = result.Items.Select(CategoryMapper.PizzaVarietyToDto).ToList(),
        //        TotalCount = result.TotalCount
        //    };
        //}

        //public async Task<BaseCategoryDto?> GetByIdAsync(Guid id)
        //{
        //    var variety = await repository.GetByIdAsync(id);

        //    return variety is null ? null : CategoryMapper.PizzaVarietyToDto(variety);
        //}

        //public async Task<bool> RemoveAsync(Guid id)
        //{
        //    var variety = await repository.GetByIdAsync(id);

        //    if (variety is null) return false;

        //    await repository.RemoveAsync(variety);
        //    return true;
        //}

        //public async Task<bool> UpdateNameAsync(BaseCategoryUpdateNameDto dto)
        //{
        //    var variety = await repository.GetByIdAsync(dto.Id);

        //    if (variety is null) return false;

        //    variety.UpdateName(dto.Name);
        //    await repository.UpdateAsync(variety);
        //    return true;
        //}
    }
}
