using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesCategoryDTOs;
using PizzaX.Application.DTOs.FriesCetagoryDTOs;
using PizzaX.Application.DTOs.FriesCetagoryDTOs.FriesCetagoryUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;
using PizzaX.Domain.Entities;

namespace PizzaX.Application.Services
{
    public sealed class FriesCategoryService : IFriesCetagoryService
    {
        private readonly IFriesCategoryRepository repository;

        public FriesCategoryService(IFriesCategoryRepository repository)
            => this.repository = repository;

        public async Task<FriesCategoryDto> CreateAsync(CreateFriesCategoryDto dto)
        {
            var category = FriesCategory.Create(
                name: dto.Name
            );

            await repository.AddAsync(category);
            return FriesCategoryMapper.ToDto(category);
        }

        public async Task<PagedResultDto<FriesCategoryDto>> GetAllAsync(FriesCategoryFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<FriesCategoryDto>
            {
                Items = result.Items.Select(FriesCategoryMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
        }

        public async Task<FriesCategoryDto?> GetByIdAsync(Guid id)
        {
            var category = await repository.GetByIdAsync(id);

            return category is null ? null : FriesCategoryMapper.ToDto(category);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var category = await repository.GetByIdAsync(id);

            if (category is null) return false;

            await repository.RemoveAsync(category);
            return true;
        }

        public async Task<bool> UpdateNameAsync(FriesCetagoryUpdateNameDto dto)
        {
            var category = await repository.GetByIdAsync(dto.Id);

            if (category is null) return false;

            category.UpdateName(dto.Name);
            await repository.UpdateAsync(category);
            return true;
        }
    }
}
