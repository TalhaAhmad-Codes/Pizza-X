using PizzaX.Application.DTOs.Common;
using PizzaX.Application.DTOs.FriesCetagoryDTOs;
using PizzaX.Application.DTOs.FriesCetagoryDTOs.FriesCetagoryUpdateDtos;
using PizzaX.Application.Interfaces.Repositories;
using PizzaX.Application.Interfaces.Services;
using PizzaX.Application.Mappers;

namespace PizzaX.Application.Services
{
    public sealed class FriesCategoryService : IFriesCetagoryService
    {
        private readonly IFriesCategoryRepository repository;

        public FriesCategoryService(IFriesCategoryRepository repository)
            => this.repository = repository;

        public async Task<PagedResultDto<FriesCategoryDto>> GetAllAsync(FriesCategoryFilterDto filterDto)
        {
            var result = await repository.GetAllAsync(filterDto);

            return new PagedResultDto<FriesCategoryDto>
            {
                Items = result.Items.Select(FriesCategoryMapper.ToDto).ToList(),
                TotalCount = result.TotalCount
            };
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
